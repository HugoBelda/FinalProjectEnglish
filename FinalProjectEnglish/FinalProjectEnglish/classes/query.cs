using System;

namespace FinalProjectEnglish.classes
{
    public class Query
    {

        public static string GetStudentInformationQuery => "SELECT * FROM students WHERE user_id = @userId";

        public static string UpdateStudentInformationQuery =>
            "UPDATE students SET nationality = @nationality, day_of_birth = @dateOfBirth, name = @name, surname = @surname, id_number = @idNumber, address = @address, email = @email WHERE user_id = @userId";
       
        public static string ViewStudentSubjectsQuery =>  "SELECT s.id, s.name, s.credits, s.semester, p.name AS professor_name, p.surname AS professor_surname " +
               "FROM subjects s " +
               "LEFT JOIN professors p ON s.professor_id = p.user_id " +
               "INNER JOIN subject_students ss ON s.id = ss.subject_id " +
               "WHERE ss.user_id = @userId";

        public static string ViewProfessorSubjects =>
            "SELECT * FROM subjects WHERE professor_id = @professorId";

        public static string studentsInSubject =>
            "SELECT students.* FROM subjects " +
                                   "LEFT JOIN subject_students ON subjects.id = subject_students.subject_id " +
                                   "LEFT JOIN students ON students.user_id = subject_students.user_id " +
                                   "WHERE subjects.id = @subjectId AND subjects.professor_id = @professorId";

        public static string logInQuery => "SELECT id, password_hash, role FROM users WHERE username = @username";

        public static string newUserStudent => "INSERT INTO users (username, password_hash, ROLE) VALUES (@username, @password_hash, @ROLE)";
        public static string newStudent => "INSERT INTO students (user_id, name, surname, day_of_birth,nationality, id_number, address, email) " +
                                "VALUES (@user_id, @name, @surname, @dbo,@nationality, @IDNumber, @address, @email)";

        public static string informationStudentGrid => "SELECT students.user_id AS id, students.name, students.surname, students.nationality, students.id_number, students.email, students.day_of_birth, (SELECT username FROM users WHERE users.id = students.user_id) AS username FROM students";


        public static string newUserProfessor => "INSERT INTO users (username, password_hash, ROLE) VALUES (@username, @password_hash, @ROLE)";

        public static string newProfessor => "INSERT INTO professors (user_id, name, surname) VALUES (@user_id, @name, @surname)";
    
        public static string newProfessorSubject => "INSERT INTO subjects (id, name, credits, semester, professor_id)" +
                                 "VALUES (@id, @name, @credits, @semester, @professor_id)";

        public static string informationProfessorsGrid => "SELECT name, surname FROM professors INNER JOIN users ON professors.user_id = users.id";

        public static string deleteStudents => "DELETE FROM students WHERE user_id = @user_id; " +
                                        "DELETE FROM professors WHERE user_id = @user_id; " +
                                        "DELETE FROM users WHERE id = @user_id;";

        public static string removeStudentFromSubject => "DELETE FROM subject_students WHERE subject_id = @subject_id AND user_id = @user_id";
        public static string addStudentToSubject => "INSERT INTO subject_students (subject_id, user_id) VALUES (@subject_id, @user_id)";

        public static string subjectsGrid => "SELECT subjects.name, subjects.credits, subjects.semester, professors.name AS professor_name, professors.surname AS professor_surname " +
                               "FROM subjects " +
                               "INNER JOIN professors ON subjects.professor_id = professors.user_id";
    }
}
