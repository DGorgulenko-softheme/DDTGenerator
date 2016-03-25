using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ChangeGen_v2
{
    public partial class Form1 : Form
    {
        private readonly ListViewColumnSorter _lvwColumnSorter;               // used for storing instance of column sorter object
        private List<Control> _connectionPageControls;       // used for storing controls of Connection page
        private List<Control> _listviewPageControls;         // used for storing controls of ListView page
        private CoreConnectionCredentials _coreCreds;        // used for storing core API credentials
        private DdtParameters _ddtParameters;                // used for storing DDT Parameters
        private Dictionary<ExchangeGeneratorParameters.MailSize, string> _mailSizeDictionary; // used for storing Mail Size possible values
        

        public Form1()
        {
            InitializeComponent();

            AddControlsToCollections();
            DisplayConnectionPage();
            GetCredsFromFileToGui();

            _lvwColumnSorter = new ListViewColumnSorter();
            lv_AgentsList.ListViewItemSorter = _lvwColumnSorter;
            lv_ExchangeServers.ListViewItemSorter = _lvwColumnSorter;
            lv_SQL.ListViewItemSorter = _lvwColumnSorter;

            lv_AgentsList.Items.Clear();
            lv_AgentsList.View = View.Details;
          
            lv_ExchangeServers.Items.Clear();
            lv_ExchangeServers.View = View.Details;

            lv_SQL.Items.Clear();
            lv_SQL.View = View.Details;

            lbl_MailSizeNote.Text =
                "*Mail size value can impact\nCore repository compression.\nRecommended value is 'Small'.";

            lbl_fillingGenerationDescription.Text =
                "*Generated files will not be\ndeleted at the end of each cycle.";
        }

        private void AddItemsToCbMailSize()
        {
            _mailSizeDictionary = new Dictionary<ExchangeGeneratorParameters.MailSize, string>();

            foreach (ExchangeGeneratorParameters.MailSize mailSize in Enum.GetValues(typeof(ExchangeGeneratorParameters.MailSize)))
            {
                switch (mailSize)
                {
                    case ExchangeGeneratorParameters.MailSize.Tiny:
                        _mailSizeDictionary.Add(mailSize,"Tiny (~10KB)");
                        break;
                    case ExchangeGeneratorParameters.MailSize.Small:
                        _mailSizeDictionary.Add(mailSize, "Small (~25KB)");
                        break;
                    case ExchangeGeneratorParameters.MailSize.Medium:
                        _mailSizeDictionary.Add(mailSize, "Medium (~100KB)");
                        break;
                    case ExchangeGeneratorParameters.MailSize.Large:
                        _mailSizeDictionary.Add(mailSize, "Large (~500KB)");
                        break;
                    case ExchangeGeneratorParameters.MailSize.VeryLarge:
                        _mailSizeDictionary.Add(mailSize, "Very Large (~1MB)");
                        break;
                    case ExchangeGeneratorParameters.MailSize.Huge:
                        _mailSizeDictionary.Add(mailSize, "Huge (~5MB)");
                        break;
                    case ExchangeGeneratorParameters.MailSize.Enormous:
                        _mailSizeDictionary.Add(mailSize, "Enormous (~10MB)");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            foreach (var mailSizeLabel in _mailSizeDictionary.Values)
            {
                cb_MailSize.Items.Add(mailSizeLabel);
            }

            cb_MailSize.SelectedIndex = 0;
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (rb_Core.Checked)
            {
                _coreCreds = new CoreConnectionCredentials
                {
                    Hostname = tb_hostname.Text,
                    Port = Convert.ToInt32(tb_Port.Text),
                    Username = tb_userName.Text,
                    Password = tb_password.Text
                };

                _coreCreds.SerizalizeCredsToFile();
               
                // Displays list of servers received from Core API to ListView
                try
                {
                    lbl_Loading.Visible = true;
                    ServerWrapper.ServersToListView(_coreCreds);
                    Logger.Log("Successfully connected to Core Server: " + tb_hostname.Text, Logger.LogLevel.Info, tb_hostname.Text);
                    
                }
                catch (WCFClientBase.ClientServerErrorException exception)
                {
                    lbl_Loading.Visible = false;
                    Logger.LogError("Cannot connect to Core server " + _coreCreds.Hostname, _coreCreds.Hostname, exception);
                    MessageBox.Show("Cannot connect to Core server." + Environment.NewLine + exception.Message, "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                catch (WCFClientBase.HttpUnauthorizedRequestException exception)
                {
                    lbl_Loading.Visible = false;
                    Logger.LogError("Cannot connect to Core server " + _coreCreds.Hostname + " Wrong credentials.", _coreCreds.Hostname, exception);
                    MessageBox.Show("Cannot connect to Core server. Incorrect credentials." + Environment.NewLine + exception.Message, "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }     
            }

            ServerWrapper.ServersListViewCreateColumns(lv_AgentsList);
            ServerWrapper.ExchangeListViewCreateColumns(lv_ExchangeServers);
            ServerWrapper.SqlListViewCreateColumns(lv_SQL);
            

            AddItemsToCbMailSize();
            GetGenParamsFromFileToGui();
            timer1.Interval = 3000; // Timer for UI update
            timer1.Start();
            lbl_Loading.Visible = false;

            // Hide Connection Page and displays ListView Page

            DisplayListViewPage();     
        }

        private void lv_AgentsList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Sort ListView by clicked column
            _lvwColumnSorter.SortColumn(e, lv_AgentsList);
        }

        private void cb_selectAllAgents_CheckedChanged(object sender, EventArgs e)
        {
            // Check/Uncheck all agents
            ControlsImplementation.SelectUnselectAll(lv_AgentsList, cb_selectAllAgents.Checked);
        }

        private void btn_StopDDT_Click(object sender, EventArgs e)
        {
            // Stop DDT for selected servers
            DdtWrapper.StopDdt(lv_AgentsList, ServerWrapper.ServersList);

            // Update ListView
            ServerWrapper.UpdateListView(lv_AgentsList, lbl_ChangeRateValue, lbl_totalAgentsRunningValue);
        }

        private void btn_startDDT_Click(object sender, EventArgs e)
        {
            var failedValidation = false;
            var textBoxValidate = new List<TextBox> {tb_Size, tb_Path, tb_Compression, tb_Interval};

            foreach (var textBox in textBoxValidate)
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text)) continue;
                errorProvider1.SetError(textBox,"Field cannot be empty");
                failedValidation = true;
            }

            if (failedValidation)
                return;



            _ddtParameters = new DdtParameters()
            {
                Filesize = Convert.ToInt32(tb_Size.Text),
                Compression = Convert.ToInt32(tb_Compression.Text),
                Interval = Convert.ToInt32(tb_Interval.Text),
                Filepath = tb_Path.Text,
                FillingGeneration = cb_fillingGeneration.Checked
            };

            _ddtParameters.SerizalizeDdtParamsToFile();

            // Start DDT for selected servers with specific parameters
            if (cb_UseCustomCredentials.Checked)
            {
                DdtWrapper.StartDdt(lv_AgentsList, ServerWrapper.ServersList, _ddtParameters, tb_customUsername.Text, tb_customPassword.Text);
            }
            else
            {
                DdtWrapper.StartDdt(lv_AgentsList, ServerWrapper.ServersList, _ddtParameters);
            }

            // Update ListView
            ServerWrapper.UpdateListView(lv_AgentsList, lbl_ChangeRateValue, lbl_totalAgentsRunningValue);
        }

        // This method displays controls for connection page
        private void DisplayConnectionPage()
        {
            ControlsImplementation.ChangePage(_listviewPageControls, _connectionPageControls);
        }

        // This method displays controls for ListView Page
        private void DisplayListViewPage()
        {
            ControlsImplementation.ChangePage(_connectionPageControls, _listviewPageControls);
        }

        // This method adds controls of Connection and ListView page to two separate collections
        private void AddControlsToCollections()
        {
            _connectionPageControls = new List<Control>();
            _listviewPageControls = new List<Control>();

            _connectionPageControls.Add(tb_hostname);
            _connectionPageControls.Add(tb_userName);
            _connectionPageControls.Add(tb_password);
            _connectionPageControls.Add(btn_Connect);
            _connectionPageControls.Add(lbl_hostname);
            _connectionPageControls.Add(lbl_username);
            _connectionPageControls.Add(lbl_password);
            _connectionPageControls.Add(tb_Port);
            _connectionPageControls.Add(lbl_Port);
            _connectionPageControls.Add(lbl_SelectMode);
            _connectionPageControls.Add(rb_Core);
            _connectionPageControls.Add(rb_Manually);

            _listviewPageControls.Add(tabControl);
        }

        private void GetCredsFromFileToGui()
        {
            var creds = CoreConnectionCredentials.DeserializeCredsFromFile();
            if (creds == null)
            {
                return;
            }

            tb_hostname.Text = creds.Hostname;
            tb_Port.Text = creds.Port.ToString();
            tb_userName.Text = creds.Username;
            tb_password.Text = creds.Password;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ServerWrapper.UpdateListView(lv_AgentsList, lbl_ChangeRateValue, lbl_totalAgentsRunningValue);
            ServerWrapper.UpdateExchangeListView(lv_ExchangeServers, lbl_exchangeGenerationRunningValue);
            ServerWrapper.UpdateSqlListView(lv_SQL, lbl_SQLGenerationRunningvalue);
            lbl_TotalAmountValue.Text = lv_AgentsList.Items.Count.ToString();
            lbl_exchangeTotalAgentsValue.Text = lv_ExchangeServers.Items.Count.ToString();
            lbl_TotalSQLServersValue.Text = lv_SQL.Items.Count.ToString();
        }

        private void GetGenParamsFromFileToGui()
        {
            var ddtParams = DdtParameters.DeserializeDdtParamsFromFile();
            if (ddtParams != null)
            {
                tb_Size.Text = ddtParams.Filesize.ToString();
                tb_Compression.Text = ddtParams.Compression.ToString();
                tb_Path.Text = ddtParams.Filepath;
                tb_Interval.Text = ddtParams.Interval.ToString();
            }

            var exchangeParams = ExchangeGeneratorParameters.DeserializeExchangeParamsFromFile();

            if (exchangeParams != null)
            {
                var i = 0;
                foreach (var item in cb_MailSize.Items)
                {

                    if ((item.ToString()).Contains(_mailSizeDictionary[exchangeParams.MessageSize]))
                        cb_MailSize.SelectedIndex = i;
                    i++;
                }
            }

            var sqlParams = SqlGeneratorParameters.DeserializeSqlParamsFromFile();

            if (sqlParams == null) return;
            tb_dbName.Text = sqlParams.DbName;
            tb_SQLAmountRows.Text = sqlParams.RowsToInsert.ToString();
        }

        private void tb_hostname_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.TextBox_ValidatingEmpty(e, (TextBox) sender, errorProvider1);
        }

        private void tb_hostname_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox) sender, errorProvider1);
        }

        private void tb_userName_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox) sender, errorProvider1);
        }

        private void tb_userName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.TextBox_ValidatingEmpty(e, (TextBox) sender, errorProvider1);
        }

        private void tb_password_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.TextBox_ValidatingEmpty(e, (TextBox) sender, errorProvider1);
        }

        private void tb_password_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox) sender, errorProvider1);
        }

        private void tb_Path_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.TextBox_ValidatingEmpty(e, (TextBox) sender, errorProvider1);
        }

        private void tb_Path_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox) sender, errorProvider1);
        }

        private void tb_Port_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.TextBox_ValidatingPort(e, (TextBox) sender, errorProvider1);
        }

        private void tb_Port_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox) sender, errorProvider1);
        }

        private void tb_Size_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox) sender, errorProvider1);
        }

        private void tb_Size_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.TextBox_ValidatingNumeric(e, (TextBox) sender, errorProvider1);
        }

        private void tb_Interval_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox) sender, errorProvider1);
        }

        private void tb_Interval_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.TextBox_ValidatingNumeric(e, (TextBox) sender, errorProvider1);
        }

        private void tb_Compression_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.TextBox_ValidatingCompression(e, (TextBox) sender, errorProvider1);
        }

        private void tb_Compression_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox) sender, errorProvider1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var box = new AboutBox1();
            box.Show();
        }

        private void btn_startExchangeGeneration_Click(object sender, EventArgs e)
        {
            if (!ExchangeGenWrapper.DoNotShowExchangePrerequisites)
            {
                var prerequisitesForm = new ExchangePrerequisites();
                prerequisitesForm.Show();
            }
                

            var messageSize = _mailSizeDictionary.FirstOrDefault(x => x.Value == cb_MailSize.SelectedItem.ToString()).Key;

            // Start Exchange Generation for selected servers with specific parameters

            if (cb_ExchangeUseCustomCreds.Checked)
            {
                ExchangeGenWrapper.StartExchangeGenerator(lv_ExchangeServers, ServerWrapper.ExchangeServersList, messageSize, tb_exchangeCustomUsername.Text, tb_exchangeCustomDomain.Text, tb_exchangeCustomPassword.Text);
            }
            else
            {
                ExchangeGenWrapper.StartExchangeGenerator(lv_ExchangeServers, ServerWrapper.ExchangeServersList, messageSize);
            }
            
            // Update ListView
            ServerWrapper.UpdateExchangeListView(lv_ExchangeServers, lbl_exchangeGenerationRunningValue);

            var exchangeParmsToSerialize = new ExchangeGeneratorParameters() {MessageSize = messageSize};
            exchangeParmsToSerialize.SerizalizeExchangeParamsToFile();
        }

        private void btn_stopExchangeGeneration_Click(object sender, EventArgs e)
        {
            // Stop DDT for selected servers
            ExchangeGenWrapper.StopExchangeGenerator(lv_ExchangeServers, ServerWrapper.ExchangeServersList);


            // Update ListView
            ServerWrapper.UpdateExchangeListView(lv_ExchangeServers, lbl_exchangeGenerationRunningValue);
        }

        private void cb_SelAllExchange_CheckedChanged(object sender, EventArgs e)
        {
            ControlsImplementation.SelectUnselectAll(lv_ExchangeServers, cb_SelAllExchange.Checked);
        }

        private void lv_ExchangeServers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Sort ListView by clicked column
            _lvwColumnSorter.SortColumn(e, lv_ExchangeServers);
        }

        private void rb_Manually_CheckedChanged(object sender, EventArgs e)
        {
            btn_Connect.Enabled = true;
            tb_hostname.Enabled = false;
            tb_password.Enabled = false;
            tb_Port.Enabled = false;
            tb_userName.Enabled = false;
        }

        private void rb_Core_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_hostname.Text) || string.IsNullOrWhiteSpace(tb_userName.Text) ||
                string.IsNullOrWhiteSpace(tb_password.Text))
                btn_Connect.Enabled = false;
            tb_hostname.Enabled = true;
            tb_password.Enabled = true;
            tb_Port.Enabled = true;
            tb_userName.Enabled = true;
        }

        private void btn_addServerManually_Click(object sender, EventArgs e)
        {
            var addServerManuallyForm = new AddServerManually();
            addServerManuallyForm.Show();
        }

        private void UpdateConnectButtonState()
        {
            btn_Connect.Enabled = !string.IsNullOrWhiteSpace(tb_hostname.Text) &&
                                   !string.IsNullOrWhiteSpace(tb_userName.Text) &&
                                   !string.IsNullOrWhiteSpace(tb_password.Text);
        }

        private void tb_hostname_TextChanged(object sender, EventArgs e)
        {
            UpdateConnectButtonState();
        }

        private void tb_userName_TextChanged(object sender, EventArgs e)
        {
            UpdateConnectButtonState();
        }

        private void tb_password_TextChanged(object sender, EventArgs e)
        {
            UpdateConnectButtonState();
        }

        private void cb_UseCustomCredentials_CheckedChanged(object sender, EventArgs e)
        {
            lbl_customUserName.Enabled = cb_UseCustomCredentials.Checked;
            lbl_customPassword.Enabled = cb_UseCustomCredentials.Checked;
            tb_customUsername.Enabled = cb_UseCustomCredentials.Checked;
            tb_customPassword.Enabled = cb_UseCustomCredentials.Checked;
            btn_StartDDT.Enabled = !cb_UseCustomCredentials.Checked;
        }

        private void tb_customUsername_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox)sender, errorProvider1);
        }

        private void tb_customUsername_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.TextBox_ValidatingEmpty(e, (TextBox)sender, errorProvider1);
        }

        private void tb_customPassword_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox)sender, errorProvider1);
        }

        private void tb_customPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.TextBox_ValidatingEmpty(e, (TextBox)sender, errorProvider1);
        }

        private void btn_deleteSelectedServers_Click(object sender, EventArgs e)
        {
            ServerWrapper.DeleteServerManually(lv_AgentsList);
        }

        private void btn_AddExchangeServerManually_Click(object sender, EventArgs e)
        {
            var addExchangeServerManuallyForm = new AddExchangeServerManually();
            addExchangeServerManuallyForm.Show();
        }

        private void btn_deleteExchangeServer_Click(object sender, EventArgs e)
        {
            ServerWrapper.DeleteExchangeServerManually(lv_ExchangeServers);
        }

        private void cb_ExchangeUseCustomCreds_CheckedChanged(object sender, EventArgs e)
        {
            lbl_exchangeCustomUsername.Enabled = cb_ExchangeUseCustomCreds.Checked;
            lbl_exchangeCustomDomain.Enabled = cb_ExchangeUseCustomCreds.Checked;
            lbl_exchangeCustomPassword.Enabled = cb_ExchangeUseCustomCreds.Checked;
            tb_exchangeCustomUsername.Enabled = cb_ExchangeUseCustomCreds.Checked;
            tb_exchangeCustomDomain.Enabled = cb_ExchangeUseCustomCreds.Checked;
            tb_exchangeCustomPassword.Enabled = cb_ExchangeUseCustomCreds.Checked;
            btn_startExchangeGeneration.Enabled = !cb_ExchangeUseCustomCreds.Checked;
        }

        private void tb_exchangeCustomUsername_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox)sender, errorProvider1);
        }

        private void tb_exchangeCustomUsername_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.TextBox_ValidatingEmpty(e, (TextBox)sender, errorProvider1);
        }

        private void tb_exchangeCustomDomain_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox)sender, errorProvider1);
        }

        private void tb_exchangeCustomDomain_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.TextBox_ValidatingEmpty(e, (TextBox)sender, errorProvider1);
        }

        private void tb_exchangeCustomPassword_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox)sender, errorProvider1);
        }

        private void tb_exchangeCustomPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.TextBox_ValidatingEmpty(e, (TextBox)sender, errorProvider1);
        }
       

        private void btn_ExchangeImportCSV_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog
            {
                Filter = "CSV File|*.csv",
                Title = "Open a CSV File"
            };
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName != "")
            {
                Csv.CsVtoExchangeServersList(openFileDialog1.FileName);
            }
        }

        private void btn_ExportCSV_Click(object sender, EventArgs e)
        {
            var saveFileDialog1 = new SaveFileDialog()
            {
                Filter = "CSV File|*.csv",
                Title = "Save a CSV File",
                FileName = "Servers.csv"
            };
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                ServerWrapper.ServersList.ServersToCsv(saveFileDialog1.FileName);
            }
        }

        private void btn_ExchangeExportCSV_Click(object sender, EventArgs e)
        {
            var saveFileDialog1 = new SaveFileDialog()
            {
                Filter = "CSV File|*.csv",
                Title = "Save a CSV File",
                FileName = "ExchangeServers.csv"
            };
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                ServerWrapper.ExchangeServersList.ExchangeServersToCsv(saveFileDialog1.FileName);
            }
        }

        private void btn_ImportCSV_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog
            {
                Filter = "CSV File|*.csv",
                Title = "Open a CSV File"
            };
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName != "")
            {
                Csv.CsVtoServersList(openFileDialog1.FileName);
            }
        }

        private void btn_StartSQLGeneration_Click(object sender, EventArgs e)
        {
            var failedValidation = false;
            var textBoxValidate = new List<TextBox> { tb_dbName, tb_SQLAmountRows };

            foreach (var textBox in textBoxValidate)
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text)) continue;
                errorProvider1.SetError(textBox, "Field cannot be empty");
                failedValidation = true;
            }

            if (failedValidation)
                return;


            var rowsToInsert = Convert.ToInt32(tb_SQLAmountRows.Text);
            var sqlParmsToSerialize = new SqlGeneratorParameters() { RowsToInsert = rowsToInsert, DbName = tb_dbName.Text };
            sqlParmsToSerialize.SerizalizeSqlParamsToFile();

            if (!SqlGenWrapper.DoNotShowSqlPrerequisites)
            {
                var prerequisitesForm = new SQLPrerequisites();
                prerequisitesForm.Show();
            }

            // Start SQL Generation for selected servers with specific parameters

            if (cb_UseCustomCredsSQL.Checked)
            {
                SqlGenWrapper.StartSqlGenerator(lv_SQL, ServerWrapper.SqlServersList, tb_dbName.Text, rowsToInsert, 
                    tb_SQLCustomUsername.Text, tb_SQLCustomPassword.Text);
            }
            else
            {
                SqlGenWrapper.StartSqlGenerator(lv_SQL, ServerWrapper.SqlServersList, tb_dbName.Text, rowsToInsert);
            }

            // Update ListView
            ServerWrapper.UpdateSqlListView(lv_SQL, lbl_SQLGenerationRunningvalue);
     
        }

        private void btn_AddSQLManually_Click(object sender, EventArgs e)
        {
            var addSqlServerManuallyForm = new AddSqlServerManually();
            addSqlServerManuallyForm.Show();
        }

        private void cb_SelectAllSQL_CheckedChanged(object sender, EventArgs e)
        {
            ControlsImplementation.SelectUnselectAll(lv_SQL, cb_SelectAllSQL.Checked);
        }

        private void btn_RemoveSQLManually_Click(object sender, EventArgs e)
        {
            ServerWrapper.DeleteSqlServerManually(lv_SQL);
        }

        private void btn_ExportCSVSQL_Click(object sender, EventArgs e)
        {
            var saveFileDialog1 = new SaveFileDialog()
            {
                Filter = "CSV File|*.csv",
                Title = "Save a CSV File",
                FileName = "SQLServers.csv"
            };
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                ServerWrapper.SqlServersList.SqlServersToCsv(saveFileDialog1.FileName);
            }
        }

        private void btn_ImportCSVSQL_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog
            {
                Filter = "CSV File|*.csv",
                Title = "Open a CSV File"
            };
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName != "")
            {
                Csv.CsVtoSqlServersList(openFileDialog1.FileName);
            }
        }

        private void btn_StopSQLGeneration_Click(object sender, EventArgs e)
        {
            // Stop SQLGeneration for selected servers
            SqlGenWrapper.StopSqlGenerator(lv_SQL,ServerWrapper.SqlServersList);

            // Update ListView
            ServerWrapper.UpdateSqlListView(lv_SQL,lbl_SQLGenerationRunningvalue);
        }

        private void cb_UseCustomCredsSQL_CheckedChanged(object sender, EventArgs e)
        {
            lbl_SQLCustomUsername.Enabled = cb_UseCustomCredsSQL.Checked;
            lbl_SQLCustomPassword.Enabled = cb_UseCustomCredsSQL.Checked;
            tb_SQLCustomUsername.Enabled = cb_UseCustomCredsSQL.Checked;
            tb_SQLCustomPassword.Enabled = cb_UseCustomCredsSQL.Checked;
            btn_StartSQLGeneration.Enabled = !cb_UseCustomCredsSQL.Checked;
        }

        private void tb_customUsername_TextChanged(object sender, EventArgs e)
        {
            UpdateStartDdtButtonState();
        }

        private void tb_customPassword_TextChanged(object sender, EventArgs e)
        {
            UpdateStartDdtButtonState();
        }

        private void tb_exchangeCustomUsername_TextChanged(object sender, EventArgs e)
        {
            UpdateStartExchangeButtonState();
        }

        private void tb_exchangeCustomDomain_TextChanged(object sender, EventArgs e)
        {
            UpdateStartExchangeButtonState();
        }

        private void tb_exchangeCustomPassword_TextChanged(object sender, EventArgs e)
        {
            UpdateStartExchangeButtonState();
        }

        private void tb_SQLCustomUsername_TextChanged(object sender, EventArgs e)
        {
            UpdateStartSqlButtonState();
        }

        private void tb_SQLCustomPassword_TextChanged(object sender, EventArgs e)
        {
            UpdateStartSqlButtonState();
        }

        private void UpdateStartExchangeButtonState()
        {
            btn_startExchangeGeneration.Enabled = !string.IsNullOrWhiteSpace(tb_exchangeCustomUsername.Text) &&
                                                  !string.IsNullOrWhiteSpace(tb_exchangeCustomDomain.Text) &&
                                                  !string.IsNullOrWhiteSpace(tb_exchangeCustomPassword.Text);
        }

        private void UpdateStartDdtButtonState()
        {
            btn_StartDDT.Enabled = !string.IsNullOrWhiteSpace(tb_customUsername.Text) &&
                                   !string.IsNullOrWhiteSpace(tb_customPassword.Text);
        }

        private void UpdateStartSqlButtonState()
        {
            btn_StartSQLGeneration.Enabled = !string.IsNullOrWhiteSpace(tb_SQLCustomUsername.Text) &&
                                             !string.IsNullOrWhiteSpace(tb_SQLCustomPassword.Text);
        }

        private void tb_dbName_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox)sender,errorProvider1);
        }

        private void tb_dbName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.TextBox_ValidatingEmpty(e,(TextBox)sender,errorProvider1);
        }

        private void tb_SQLAmountRows_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox)sender, errorProvider1);
        }

        private void tb_SQLAmountRows_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.TextBox_ValidatingNumeric(e, (TextBox)sender, errorProvider1);
        }

        private void tb_SQLCustomUsername_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox)sender, errorProvider1);
        }

        private void tb_SQLCustomUsername_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.TextBox_ValidatingEmpty(e, (TextBox)sender, errorProvider1);
        }

        private void tb_SQLCustomPassword_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox)sender, errorProvider1);
        }

        private void tb_SQLCustomPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.TextBox_ValidatingEmpty(e, (TextBox)sender, errorProvider1);
        }

        private void lv_SQL_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Sort ListView by clicked column
            _lvwColumnSorter.SortColumn(e, lv_SQL);
        }
    }
}
