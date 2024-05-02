using System;
using System.Data.SQLite;

namespace FinalProjectEnglish.classes
{
    public class Student
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nationality { get; set; }
        public string DateOfBirth { get; set; }
        public string IdNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public Student(int userId, string name, string surname, string nationality, string dateOfBirth, string idNumber, string address, string email)
        {
            UserId = userId;
            Name = name;
            Surname = surname;
            Nationality = nationality;
            DateOfBirth = dateOfBirth;
            IdNumber = idNumber;
            Address = address;
            Email = email;
        }

        public void UpdateInformation(SQLiteConnection conn)
        {
            try
            {
                string updateQuery = "UPDATE students SET ";
                bool anyUpdate = false;

                if (!string.IsNullOrEmpty(Nationality))
                {
                    updateQuery += "nationality = @nationality, ";
                    anyUpdate = true;
                }

                if (!string.IsNullOrEmpty(DateOfBirth))
                {
                    updateQuery += "day_of_birth = @dateOfBirth, ";
                    anyUpdate = true;
                }

                if (!string.IsNullOrEmpty(IdNumber))
                {
                    updateQuery += "id_number = @idNumber, ";
                    anyUpdate = true;
                }

                if (!string.IsNullOrEmpty(Address))
                {
                    updateQuery += "address = @address, ";
                    anyUpdate = true;
                }

                if (!string.IsNullOrEmpty(Email))
                {
                    updateQuery += "email = @email, ";
                    anyUpdate = true;
                }
                if (!string.IsNullOrEmpty(Surname))
                {
                    updateQuery += "surname = @surname, ";
                    anyUpdate = true;
                }
                if (!string.IsNullOrEmpty(Name))
                {
                    updateQuery += "name = @name, ";
                    anyUpdate = true;
                }

                if (anyUpdate)
                {
                    updateQuery = updateQuery.TrimEnd(',', ' ');

                    updateQuery += " WHERE user_id = @userId";

                    using(SQLiteCommand updateCmd = new SQLiteCommand(updateQuery, conn))
{
                        updateCmd.Parameters.AddWithValue("@userId", UserId);
                        if (!string.IsNullOrEmpty(Nationality))
                            updateCmd.Parameters.AddWithValue("@nationality", Nationality);
                        if (!string.IsNullOrEmpty(DateOfBirth))
                            updateCmd.Parameters.AddWithValue("@dateOfBirth", DateOfBirth);
                        if (!string.IsNullOrEmpty(IdNumber))
                            updateCmd.Parameters.AddWithValue("@idNumber", IdNumber);
                        if (!string.IsNullOrEmpty(Address))
                            updateCmd.Parameters.AddWithValue("@address", Address);
                        if (!string.IsNullOrEmpty(Email))
                            updateCmd.Parameters.AddWithValue("@email", Email);
                        if (!string.IsNullOrEmpty(Surname)) 
                            updateCmd.Parameters.AddWithValue("@surname", Surname);
                        if (!string.IsNullOrEmpty(Name))
                            updateCmd.Parameters.AddWithValue("@name", Name);

                        updateCmd.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
