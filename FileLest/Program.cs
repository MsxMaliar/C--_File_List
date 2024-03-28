using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using static System.Net.WebRequestMethods;


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
    public void GetFiles()
    {
        string[] files = Directory.GetFiles(mDirName);
        foreach (string s in files)
        {
            Console.WriteLine("[F]   ");
            Console.WriteLine(s);
        }
    }

    public void GetDirectorys()
    {
        string[] dirs = Directory.GetDirectories(mDirName);
        foreach (string s in dirs)
        {
            Console.WriteLine("[D]   ");
            Console.WriteLine(s);
        }
    }
}

static class Program
{

    

    static int Main()
    {

        var dirPars = new DirPars("C:\\Users\\malya\\C#-program\\FileLest\\TestDirectory");

        dirPars.GetAllList();

        dirPars.GetFiles();

        dirPars.GetDirectorys();




        return 0;
    }
}