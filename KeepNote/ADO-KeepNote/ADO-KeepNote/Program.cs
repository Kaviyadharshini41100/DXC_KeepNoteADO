using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
namespace ADO_KeepNote
{
    class TakeNote
    {
        public  void CreateNote(SqlConnection con)
        {
            
            SqlDataAdapter adp = new SqlDataAdapter("Select * from takeNote", con);
            DataSet ds = new DataSet();
            adp.Fill(ds,"NoteTable");   
            var row = ds.Tables["NoteTable"].NewRow();
            Console.WriteLine("Enter Title:");
            string Title=Console.ReadLine();
            Console.WriteLine("Enter Description:");
            string descriptions=Console.ReadLine(); 
            DateTime date = DateTime.Now;
            row["Title"] = Title;
            row["Descriptions"]=descriptions;
            row["Dates"]=date;
            ds.Tables["NoteTable"].Rows.Add(row);
            SqlCommandBuilder cmd = new SqlCommandBuilder(adp);
            adp.Update(ds,"NoteTable");
            Console.WriteLine("Notes Created successfully");
        }
        public void ViewNoteID(SqlConnection con)
        {
            Console.WriteLine("Enter ID");
            int Id = Convert.ToInt32(Console.ReadLine());
            SqlDataAdapter adp = new SqlDataAdapter($"Select * from  takeNote where id={Id}", con);
            DataSet ds = new DataSet();
            adp.Fill(ds, "NoteTable");
            for (int i = 0; i < ds.Tables["NoteTable"].Rows.Count; i++)
            {
                Console.WriteLine("id | Title | Descriptions | dates");
                for (int j = 0; j < ds.Tables["NoteTable"].Columns.Count; j++)
                {
                    Console.Write($"{ds.Tables["NoteTable"].Rows[i][j]} |");
                }
                Console.WriteLine();

            }
        }
        public void ViewallNotes(SqlConnection con) 
        {
           
            SqlDataAdapter adp = new SqlDataAdapter("Select * from takeNote", con);
            DataSet ds = new DataSet();
            adp.Fill(ds, "NoteTable");
            for(int i = 0; i < ds.Tables["NoteTable"].Rows.Count; i++)
            {
                for (int j = 0; j < ds.Tables["NoteTable"].Columns.Count;j++)
                {
                    Console.Write($"{ds.Tables["NoteTable"].Rows[i][j]} |");
                }
                Console.WriteLine();
            }


        }
        public void UpdateNote(SqlConnection con)
        {
            Console.WriteLine("Enter Id");
            int Id = Convert.ToInt32(Console.ReadLine());
            SqlDataAdapter adp = new SqlDataAdapter($"select * from takeNote where id={Id}", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            var row = ds.Tables[0].Rows[0];
            Console.WriteLine("Enter title for update: ");
            string Title = Console.ReadLine();
            Console.WriteLine("Enter description for update: ");
            string Descriptions = Console.ReadLine();
            DateTime Date = DateTime.Now;
            row["Title"] = Title;
            row["Descriptions"] = Descriptions;
            row["Dates"] = Date;
            SqlCommandBuilder cmd = new SqlCommandBuilder(adp);
            adp.Update(ds);
            Console.WriteLine(" Updated Successfully ");
        }
        public void DeleteNote(SqlConnection con) 
        {
            Console.WriteLine("Enter the id");
            int Id = Convert.ToInt32(Console.ReadLine());
            SqlDataAdapter adp = new SqlDataAdapter($"select * from takeNote where id = {Id}", con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            ds.Tables[0].Rows[0].Delete();
            SqlCommandBuilder cmd = new SqlCommandBuilder(adp);
            adp.Update(ds);
            Console.WriteLine("Deleted Successfully!");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
            TakeNote obj = new TakeNote();
            while (true)
            {
                SqlConnection con = new SqlConnection("Server=IN-2HRQ8S3; database=KeepNotes; Integrated Security=true");
                Console.WriteLine("1  Create Note");
                Console.WriteLine("2  View NoteId");
                Console.WriteLine("3  ViewallNotes");
                Console.WriteLine("4  Update Notes");
                Console.WriteLine("5  Delete Note");
                try
                {
                    Console.WriteLine("Enter your choice");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                                obj.CreateNote(con);
                                break;
                            }
                        case 2:
                            {
                                obj.ViewNoteID(con);
                                break;
                            }
                        case 3:
                            {
                                obj.ViewallNotes(con);
                                break;
                            }
                        case 4:
                            {
                                obj.UpdateNote(con);
                                break;
                            }
                        case 5:
                            {
                                obj.DeleteNote(con);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Enter a valid option");
                                break;
                            }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter only Numbers From 1 to 5");
                }


            }

        }
    }
}