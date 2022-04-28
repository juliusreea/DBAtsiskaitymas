using DBAtsiskaitymas.Functionalities;
namespace DBAtsiskaitymas

{
    public class Program
    {
        static void Main(string[] args)
        {
            DataProcedures procedures = new DataProcedures();
            Printer printer = new Printer();

            //sukuriame paskaitas
            var informacinesTech = procedures.AddLecture("Informacines Technologijos");
            var anglu = procedures.AddLecture("Anglu Kalba");
            var matematika = procedures.AddLecture("Diskrecioji matematika");
            var chemija = procedures.AddLecture("Chemija");
            var spektometrija = procedures.AddLecture("Spektrometrija");
            var fizika = procedures.AddLecture("Fizika");
            var vokieciu = procedures.AddLecture("Vokieciu kalba");



            //sukuriame departamenta ir priskiriame jam paskaitas
            var fizikosDep = procedures.CreateDepartmentWithLectures("Fizikos mokslu fakultetas", new() { spektometrija, fizika, matematika });
            var ekonomikosDep = procedures.CreateDepartmentWithLectures("Ekonomikos fakultetas", new() { anglu, matematika });
            var gamtosDep = procedures.CreateDepartmentWithLectures("Gamtos mokslu fakultetas", new() { spektometrija, fizika, chemija });
            var tiksliujuDep = procedures.CreateDepartmentWithLectures("Tiksliuju mokslu fakultetas", new() { informacinesTech, anglu, matematika });


            //sukuriame studentus ir priskiriame prie egsiztuojancio departamento ir priskiriame egzistuojancias paskaitas
            var student1 = procedures.AddStudent("Saulius", "Tolstojus", fizikosDep, new() { fizika, vokieciu, informacinesTech });
            var student2 = procedures.AddStudent("Gvidas", "Meskonis", ekonomikosDep, new() { anglu, matematika, informacinesTech });
            var student3 = procedures.AddStudent("rimas", "Jonaitis", gamtosDep, new() { informacinesTech, vokieciu });
            var student4 = procedures.AddStudent("Jonas", "Jonaitis", fizikosDep, new() { informacinesTech, fizika, anglu });
            var student5 = procedures.AddStudent("Arvyas", "Baranauskas", ekonomikosDep, new() { anglu, matematika, informacinesTech });


            //perkeliame studenta i kita departamenta, nurodome departamenta ir paskaitu sarasa
            procedures.TransferStudent("rimas", "Jonaitis", fizikosDep, new() { fizika, matematika, informacinesTech });


            //atspausdiname visus departamento studentus
            printer.ViewAllStudentsByDepartment(ekonomikosDep);

            //spausdiname visas departamento paskaitas
            printer.ViewAllLecturesByDepartment(gamtosDep);

            //spausdiname visas paskaitas pagal studenta
            printer.ViewAllLecturesByStudent(student3);

        }
    }
}
