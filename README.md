# FolderBrowserForWPF
Use the Windows Vista / Windows 7 Folder Browser Dialog from your WPF projects, without any additional dependencies.

3Q  @hbarck https://archive.codeplex.com/?p=wpffolderbrowser


# Net8.0 Publish. so this repo is no longer useful 
var folderDialog = new OpenFolderDialog
{
    Title = "Select Folder",
    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)
};

if (folderDialog.ShowDialog() == true)
{
    var folderName = folderDialog.FolderName;
    MessageBox.Show($"You picked ${folderName}!");
}
