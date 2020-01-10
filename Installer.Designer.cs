namespace ClearExcelService
{
    partial class Installer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProjectProcessEscel = new System.ServiceProcess.ServiceProcessInstaller();
            this.Project = new System.ServiceProcess.ServiceInstaller();

            this.ProjectProcessEscel.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.ProjectProcessEscel.Password = null;
            this.ProjectProcessEscel.Username = null;

            this.Project.ServiceName = "Gaia.Service.ClearExcel";
            this.Project.StartType = System.ServiceProcess.ServiceStartMode.Automatic;

            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.ProjectProcessEscel,
            this.Project
            });
        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller ProjectProcessEscel;
        private System.ServiceProcess.ServiceInstaller Project;
    }
}