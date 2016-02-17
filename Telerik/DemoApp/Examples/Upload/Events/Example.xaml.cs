using System;
using System.Windows;
using Telerik.Windows.Controls;

namespace Telerik.Windows.Examples.Upload.Events
{
    public partial class Example : System.Windows.Controls.UserControl
    {
        public Example()
        {
            InitializeComponent();
        }

        private void RadUpload_FilesSelected(object sender, FilesSelectedEventArgs e)
        {
            Status_EventEnter("FilesSelected");
            Status_Write("FileCount: " + e.SelectedFiles.Count);
            Status_Write("FirstFile Name: " + e.SelectedFiles[0].Name);
            Status_EventEnd("FilesSelected");
        }

        private void RadUpload_FileTooLarge(object sender, FileEventArgs e)
        {
            Status_EventEnter("FileTooLarge");
            Status_Write("File: " + e.SelectedFile.Name + " | " + e.SelectedFile.Size);
            Status_EventEnd("FileTooLarge");
        }

        private void RadUpload_FileUploaded(object sender, FileUploadedEventArgs e)
        {
            Status_EventEnter("FileUploaded");
            Status_Write("Uploaded File:" + e.SelectedFile.Name + " | " + e.HandlerData.IsSuccess);
            Status_EventEnd("FileUploaded");
        }

        private void RadUpload_FileUploadFailed(object sender, FileUploadFailedEventArgs e)
        {
            Status_EventEnter("FileUploadFailed");
            e.ErrorMessage = "My Message";
            Status_Write("Failed Message:" + e.HandlerData.Message);
            Status_EventEnd("FileUploadFailed");
        }

        private void RadUpload_FileUploadStarting(object sender, FileUploadStartingEventArgs e)
        {
            RadUpload upload1 = sender as RadUpload;
            Status_EventEnter("FileUploadStarting");
            e.FileParameters.Add("myParam1", "myParam1Value");
            Status_Write("Uploading File:" + e.SelectedFile.Name + " | " + e.UploadData.FileName);
            Status_EventEnd("FileUploadStarting");
        }

        private void RadUpload_ProgressChanged(object sender, EventArgs e)
        {
            RadUpload upload1 = sender as RadUpload;
            Status_EventEnter("ProgressChanged");
            DumpCurrentSession(sender);
            Status_EventEnd("ProgressChanged");
        }

        private void DumpCurrentSession(object sender)
        {
            RadUpload upload1 = sender as RadUpload;
            Status_Write("Current Progress:" + (upload1.CurrentSession.CurrentProgress * 100).ToString());
            Status_Write("Current File:" + upload1.CurrentSession.CurrentFile.Name);
            Status_Write("Current FileProgress:" + upload1.CurrentSession.CurrentFileProgress);
            Status_Write("TotalFilesCount:" + upload1.CurrentSession.TotalFilesCount);
            Status_Write("TotalFileSize:" + upload1.CurrentSession.TotalFileSize);
            Status_Write("UploadedBytes:" + upload1.CurrentSession.UploadedBytes);
            Status_Write("UploadedFilesCount:" + upload1.CurrentSession.UploadedFiles.Count);
        }

        private void RadUpload_UploadCanceled(object sender, EventArgs e)
        {
            RadUpload upload1 = sender as RadUpload;
            Status_EventEnter("UploadCanceled");
            Status_Write("Current File is:" + upload1.CurrentSession.CurrentFile.Name);
            Status_EventEnd("UploadCanceled");
        }

        private void RadUpload_UploadFinished(object sender, EventArgs e)
        {
            Status_EventEnter("UploadFinished");
            DumpCurrentSession(sender);
            Status_EventEnd("UploadFinished");
        }

        private void RadUpload_UploadPaused(object sender, EventArgs e)
        {
            Status_EventEnter("UploadPaused");
            Status_EventEnd("UploadPaused");
        }

        private void RadUpload_UploadResumed(object sender, EventArgs e)
        {
            Status_EventEnter("UploadResumed");
            Status_EventEnd("UploadResumed");
        }

        private void RadUpload_UploadSizeExceeded(object sender, RoutedEventArgs e)
        {
            Status_EventEnter("UploadSizeExceeded");
            Status_EventEnd("UploadSizeExceeded");
        }

        private void RadUpload_UploadStarted(object sender, UploadStartedEventArgs e)
        {
            Status_EventEnter("UploadStarted");
            Status_EventEnd("UploadStarted");
        }
        private void Status_EventEnd(string p)
        {
            this.Dispatcher.BeginInvoke(new Action(() => TextOutput.Text = "-/----" + p + "\n" + TextOutput.Text));
        }

        private void Status_Write(string p)
        {
            this.Dispatcher.BeginInvoke(new Action(() => TextOutput.Text = "-" + p + "\n" + TextOutput.Text));
        }

        private void Status_EventEnter(string p)
        {
            this.Dispatcher.BeginInvoke(new Action(() => TextOutput.Text = "-----" + p + "\n" + TextOutput.Text));
        }

        private void btnClear_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            TextOutput.Text = "";
        }

        private void RadUpload_FileCountExceeded(object sender, RoutedEventArgs e)
        {
            Status_EventEnter("FileCountExceeded");
            Status_EventEnd("FileCountExceeded");
        }
    }
}

