using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Diagnostics;

struct DirectoryEmty
{
    public string name;
    public bool empty;
}

class ListFile
{
    string filePath;

    public ListFile(string path)
    {
        filePath = path;

        if (!File.Exists(filePath))
        {
            File.Create(filePath);
        }
    }

    public void WriteList(List<string> files)
    {
        File.WriteAllLines(filePath, files);
    }


}

class DirPars
{
    string mDirName;
    public DirPars(string dirName)
    {
        mDirName = dirName;
    }

    public void GetAllList()
    {
        string[] files = Directory.GetFiles(mDirName, "", SearchOption.AllDirectories);
        foreach (string s in files)
        {
            Console.WriteLine("[F]   ");
            Console.WriteLine(s);
        }

        Console.WriteLine("\n");

        string[] dirs = Directory.GetDirectories(mDirName, "", SearchOption.AllDirectories);
        foreach (string s in dirs)
        {
            Console.WriteLine("[D]   ");
            Console.WriteLine(s);
        }
    }
    public List<string> GetFiles()
    {
        string[] files = Directory.GetFiles(mDirName, "", SearchOption.AllDirectories);
        List<string> list = new List<string>(files);

        return list;
    }

    public List<DirectoryEmty> GetDirectorys()
    {
        string[] dirs = Directory.GetDirectories(mDirName, "", SearchOption.AllDirectories);
        List<DirectoryEmty> list = new List<DirectoryEmty>() ;

        DirectoryEmty listItem;

        foreach (string s in dirs)
        {

            listItem.name = s;

            if (Directory.GetDirectories(s).Any())
            {
                listItem.empty = true;
            }
            else
            {
                listItem.empty = false;
            }

            list.Add(listItem);

        }

        return list;
    }

}

static class Program
{

    

    static int Main()
    {
        var lisrtFile = new ListFile("C:\\Users\\malya\\C#-program\\FileLest\\C--_File_List\\ListFile.txt");

        var dirPars = new DirPars("C:\\Users\\malya\\C#-program\\FileLest\\C--_File_List\\TestDirectory");

        dirPars.GetAllList();

        dirPars.GetFiles();

        dirPars.GetDirectorys();


        lisrtFile.WriteList(dirPars.GetFiles());


        return 0;
    }
}