using System;
using System.Collections;
using System.Diagnostics;
using System.IO;

namespace CYCU_Course_Selection_Helper
{
    public class FileIO
    {
        public static bool SaveListToTxt(string fpath, ArrayList list)
        {
            StreamWriter file = null;
            try
            {
                file = new StreamWriter(fpath);

                foreach (string line in list)
                {
                    file.WriteLine(line);
                }
                return true;
            }
            catch(Exception ex)
            {
                Debug.Print(ex.Message);
                return false;
            }
            finally
            {
                if (file != null) file.Close();
            }
        }

        public static bool LoadFileFromTxt(string fpath, out ArrayList list)
        {
            StreamReader file = null;
            list = new ArrayList();

            try
            {
                file = new StreamReader(fpath);

                while (!file.EndOfStream)
                {
                    list.Add(file.ReadLine());
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                return false;
            }
            finally
            {
                if (file != null) file.Close();
            }
        }
    }
}
