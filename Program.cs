﻿using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
static void OutputFileSystemInfo()
{
    WriteLine("{0,-33} {1}", arg0: "Path.PathSeparator",
    arg1: PathSeparator);
    WriteLine("{0,-33} {1}", arg0: "Path.DirectorySeparatorChar",
    arg1: DirectorySeparatorChar);
    WriteLine("{0,-33} {1}", arg0: "Directory.GetCurrentDirectory()",
    arg1: GetCurrentDirectory());
    WriteLine("{0,-33} {1}", arg0: "Environment.CurrentDirectory",
    arg1: CurrentDirectory);
    WriteLine("{0,-33} {1}", arg0: "Environment.SystemDirectory",
    arg1: SystemDirectory);
    WriteLine("{0,-33} {1}", arg0: "Path.GetTempPath()",
    arg1: GetTempPath());
    WriteLine("GetFolderPath(SpecialFolder");
    WriteLine("{0,-33} {1}", arg0: " .System)",
    arg1: GetFolderPath(SpecialFolder.System));
    WriteLine("{0,-33} {1}", arg0: " .ApplicationData)",
    arg1: GetFolderPath(SpecialFolder.ApplicationData));
    WriteLine("{0,-33} {1}", arg0: " .MyDocuments)",
    arg1: GetFolderPath(SpecialFolder.MyDocuments));
    WriteLine("{0,-33} {1}", arg0: " .Personal)",
    arg1: GetFolderPath(SpecialFolder.Personal));
    WriteLine("{0,-33} {1}", arg0: "OsVersion", arg1: OSVersion);
}


static void WorkWithDrives()
{
    WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18} | {4,18}",
 "NAME", "TYPE", "FORMAT", "SIZE (BYTES)", "FREE SPACE");
foreach (DriveInfo drive in DriveInfo.GetDrives())
{
    if (drive.IsReady)
    {
        WriteLine(
        "{0,-30} | {1,-10} | {2,-7} | {3,18:N0} | {4,18:N0}",
        drive.Name, drive.DriveType, drive.DriveFormat,
        drive.TotalSize, drive.AvailableFreeSpace);
    }
    else
    {
        WriteLine("{0,-30} | {1,-10}", drive.Name, drive.DriveType);
    }
}
}

static void WorkWithDirectories()
{
    // define a directory path for a new folder
    // starting in the user's folder
    string newFolder = Combine(
    GetFolderPath(SpecialFolder.Personal),
    "Code", "Chapter09", "NewFolder");
    WriteLine($"Working with: {newFolder}");
    // check if it exists
    WriteLine($"Does it exist? {Exists(newFolder)}");
    // create directory
    WriteLine("Creating it...");
    CreateDirectory(newFolder);
    WriteLine($"Does it exist? {Exists(newFolder)}");
    Write("Confirm the directory exists, and then press ENTER: ");
    ReadLine();

    // delete directory
    WriteLine("Deleting it...");
    Delete(newFolder, recursive: true);
    WriteLine($"Does it exist? {Exists(newFolder)}");
}
static void WorkWithFiles()
{
    string dir = Combine(
 GetFolderPath(SpecialFolder.Personal),
 "Code", "Chapter09", "OutputFiles");
    CreateDirectory(dir);
    Console.WriteLine($"Directory exists: {Exists(dir)}");
    string textFile = Combine(dir, "smth.txt");
    string backupFile = Combine(dir, "smth.bak");
    WriteLine($"Working with: {textFile}");
    WriteLine($"Does it exists?{File.Exists(textFile)}");
    StreamWriter textWriter = File.CreateText(textFile);
    textWriter.WriteLine("Text File Created!");
    textWriter.Close();
    WriteLine($"Does it exists? {File.Exists(textFile)}");
    File.Copy(backupFile, backupFile, true);
    WriteLine(
 $"Does {backupFile} exist? {File.Exists(backupFile)}");
    Write("Confirm the files exist, and then press ENTER: ");
    ReadLine();
    File.Delete(textFile);
    Console.WriteLine($"does Original file exist? {File.Exists(textFile)}");
    WriteLine("Reading text from backup file");
    StreamReader streamReader = File.OpenText(backupFile);
    WriteLine(streamReader.ReadToEnd());
    streamReader.Close();
}

WorkWithFiles();
//OutputFileSystemInfo();
WriteLine();
//WorkWithDrives();
WorkWithDirectories();

