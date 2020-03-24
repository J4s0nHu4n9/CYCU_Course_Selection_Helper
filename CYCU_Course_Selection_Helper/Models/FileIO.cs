using System;
using System.Collections;
using System.Diagnostics;
using System.IO;

namespace CYCU_Course_Selection_Helper.Models
{
    public static class FileIo
    {
        public static void SaveListToTxt(string filePath, ArrayList list)
        {
            StreamWriter file = null;
            try
            {
                file = new StreamWriter(filePath);

                foreach (string line in list)
                {
                    file.WriteLine(line);
                }
            }
            catch(Exception ex)
            {
                Debug.Print(ex.Message);
            }
            finally
            {
                file?.Close();
            }
        }

        public static void LoadFileFromTxt(string filePath, out ArrayList list)
        {
            StreamReader file = null;
            list = new ArrayList();

            try
            {
                file = new StreamReader(filePath);

                while (!file.EndOfStream)
                {
                    list.Add(file.ReadLine());
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            finally
            {
                file?.Close();
            }
        }
    }
}
