using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSQLImageTest
{
    public class DataFile
    {
        private readonly int _fileid;
        private readonly byte[] _data;
        private readonly string _filetype;
        private readonly int _filesize;
        private readonly string _filename;
        private readonly string _extention;

        public DataFile() { }

        public DataFile(int fileid, byte[]data, string filetype, int filesize, string filename, string extention)
        {
            _fileid = fileid;
            _data = data;
            _filetype = filetype;
            _filesize = filesize;
            _filename = filename;
            _extention = extention;
        }

        public int FileId
        {
            get { return _fileid; }
        }

        public byte[] Data
        {
            get { return _data; }
        }

        public string FileType
        {
            get { return _filetype; }
        }

        public int FileSize
        {
            get { return _filesize; }
        }

        public string FileName
        {
            get { return _filename; }
        }

        public string Extention
        {
            get { return _extention; }
        }

        public static List<DataFile> SelectDataFileList()
        {
            var myDataFileList = new List<DataFile>();

            using (var conn = DbConnections.GetSqlConnection())
            {
                var myCommand = new SqlCommand("cp_SelectDataFile", conn) { CommandType = CommandType.StoredProcedure };


                conn.Open();

                var dbReader = myCommand.ExecuteReader();

                while (dbReader.Read())
                {
                    myDataFileList.Add(new DataFile(
                    dbReader.GetInt32(0),
                    (byte[])dbReader.GetValue(1),
                    dbReader.GetString(2),
                    dbReader.GetInt32(3),
                    dbReader.GetString(4),
                    dbReader.GetString(5)));
                }
                dbReader.Close();
                dbReader.Dispose();

                myCommand.Dispose();
                conn.Close();
                conn.Dispose();
            }
            return myDataFileList;
        }

        public static int InsertDataFile(byte[] data, string filetype, int filesize, string filename, string extention)
        {
            int i;
            using (var conn = DbConnections.GetSqlConnection())
            {
                var myCommand = new SqlCommand("cp_InsertDataFile", conn) { CommandType = CommandType.StoredProcedure };

                myCommand.Parameters.AddWithValue("@Data", data);
                myCommand.Parameters.AddWithValue("@FileType", filetype);
                myCommand.Parameters.AddWithValue("@FileSize", filesize);
                myCommand.Parameters.AddWithValue("@FileName", filename);
                myCommand.Parameters.AddWithValue("@Extention", extention);

                conn.Open();

                var returnValue = new SqlParameter("returnVal", SqlDbType.Int) { Direction = ParameterDirection.ReturnValue };
                myCommand.Parameters.Add(returnValue);

                myCommand.ExecuteNonQuery();
                i = Convert.ToInt32(returnValue.Value);

                myCommand.Dispose();
                conn.Close();
                conn.Dispose();
            }

            return i;
        } 
    } 
}
