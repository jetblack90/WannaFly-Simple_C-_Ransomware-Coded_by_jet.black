using static System.Console;
using static System.ConsoleColor;

// Set the "encrypt" bool to TRUE to Encrypt the files, or FALSE to decrypt the files
bool encrypt = true;

// Set a folder directory to encrypt/decrypt files
string dir = @"C:\MyFolder";

// Set a password for the crypted files
string encryptonPassword = "MY_PASSWORD";

// Trigger file listing
List<string> files = new List<string>();
DirectoryInfo d = new DirectoryInfo(dir);

// List of (types of) files
foreach (var file in d.GetFiles("*.png"))
{
    files.Add(file.ToString());
}
foreach (var file in d.GetFiles("*.mp4"))
{
    files.Add(file.ToString());
}
foreach (var file in d.GetFiles("*.gif"))
{
    files.Add(file.ToString());
}
foreach (var file in d.GetFiles("*.jpeg"))
{
    files.Add(file.ToString());
}
foreach (var file in d.GetFiles("*.jpg"))
{
    files.Add(file.ToString());
}
foreach (var file in d.GetFiles("*.txt"))
{
    files.Add(file.ToString());
}
foreach (var file in d.GetFiles("*.exe"))
{
    files.Add(file.ToString());
}
foreach (var file in d.GetFiles("*.Ink"))
{
    files.Add(file.ToString());
}

if (encrypt == true)
{
    // Encrypt all files

    foreach (string file in files)
    {
        string encryptedFile = dir + "Encrypted_files.txt";
        SharpAESCrypt.SharpAESCrypt.Encrypt(encryptonPassword, file, encryptedFile);

        //string decryptedFile = dir + "decrypted.text";

        File.Delete(file);
        File.Move(encryptedFile, file);

        ForegroundColor = DarkRed;
        WriteLine("File Encrypted!");
    }
    ResetColor();
}
else if (encrypt == false)
{
    // Decrypt all files

    foreach (string file in files)
    {
        string decryptedFile = dir + "Encrypted_file.txt";
        SharpAESCrypt.SharpAESCrypt.Decrypt(encryptonPassword, file, decryptedFile);

        //string decryptedFile = dir + "decrypted.text";

        File.Delete(file);
        File.Move(decryptedFile, file);

        ForegroundColor = Green;
        WriteLine("File Decrypted!");
    }
    ResetColor();
}
else
{
    ForegroundColor = DarkRed;
    WriteLine("ERROR!");
    ResetColor();
}