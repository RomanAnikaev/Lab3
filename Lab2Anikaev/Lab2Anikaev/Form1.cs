using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab2Anikaev
{
    public partial class Form1 : Form
    {
        public static Random r = new Random();

        Univers[] univer = new Univers[5];
        //чоловічі імя
        public static string[] male_names = { "Fry", "Met", "Kris",
      "Kiril", "Dok", "Mike", "Jek", "Nikita", "Den", "Kir"};
        //жіночі імя
        public static string[] female_names = { "Lilla", "Misa", "Soni",
      "Mellisa", "Zinaida", "Zinna", "Rita" };
        //Прізвище
        public static string[] m_f_surnames = { "Williams", "Evans", "Stone", "Roberts", "Mills", "Lewis", "Morgan", "Florence",
            "Campbell", "Bronte", "Bell", "Adams", "Peters", "Gibson", "Martin", "Jordan", "Grant", "Davis", "Collins", "Barlow" };
        //По-батькові
        public static string[] patronymic = { "Mackenzie", "Jobeth", "Cruise", "Stuart", "Charles", "Burton"};
        //Факультет
        public static string[] n_faculty = { "Филологический", "Философский", "Психологии", "Социологии", "Юридический" };
        //номер курсу
        public static string[] n_course = { "I", "II", "III", "IV", "V"};
        //Посада
        public static string[] posit = { "комендант", "завгосп", "охоронець", "прибиральник"};
        //Група
        public static string[] n_group = { "Fil_Che", "Fil_Ki", "Psi_Ch", "So_Ce", "Yri_Dic" };
        //заробіток
        public static int n_income = 0;
        //ідентифікатор для Dictionary<int, Student>
        public static int id_diction = 0;
        //фактична кількість мешканців
        public static int col_stud = 0;

        public int Kol = 0;//кількість універів
        //List<Room> rooms = new List<Room>();
        //List<Worker> workers = new List<Worker>();
        //Dictionary<int, Student> students = new Dictionary<int, Student>();

        public class Room
        {
            public int unq_nmb;//unique number(Унікальний номер)
            public int poss_res;//possible resident(кількість можливих мешканців)
            public int act_res;//number of actual residents(кількість фактичних мешканців)
            public int ct_liv;//cost of living(вартість проживання)
            public string room_tp;//room type(тип кімнати)
            public string[] arr_id = new string[4];//array of identifiers(массив ідентифікаторів студентів кімнати)
            
            public Room(int stud, int stud1)//stud1-кількість студентів на зачислення, stud - фактичні мешканці
            {
                int temp;//для ідентифікаторів
                //int stud1 = stud;
                int j = r.Next(1,3);
                if(j == 1) room_tp = "Standart";
                else if(j == 2) room_tp = "Comfort";
                else room_tp = "Single";
                unq_nmb = r.Next(1, 1000);//номер кімнати
                //кількість можливих мешканців
                if (room_tp == "Standart")
                {
                    poss_res = 4;
                    ct_liv = 400;//вартість
                    if (stud < stud1)
                    {
                        act_res = r.Next(1, 4);//фактичних мешканців(от 1 до 4)

                        if (act_res == 1)
                        {
                            temp = r.Next(10000000, 99999999);
                            arr_id[0] = temp.ToString();
                            n_income += ct_liv;
                        }//ідентифікатори
                        else if (act_res == 2) for (int i = 0; i < 2; i++)
                            {
                                temp = r.Next(10000000, 99999999);
                                arr_id[i] = temp.ToString();
                                n_income += ct_liv * 2;

                            }
                        else if (act_res == 3) for (int i = 0; i < 3; i++)
                            {
                                temp = r.Next(10000000, 99999999);
                                arr_id[i] = temp.ToString();
                                n_income += ct_liv * 3;
                            }
                        else if (act_res == 4) for (int i = 0; i < 4; i++)
                            {
                                temp = r.Next(10000000, 99999999);
                                arr_id[i] = temp.ToString();
                                n_income += ct_liv * 4;
                            }
                    }
                    else act_res = 0;//фактичних мешканців(= 0)
                    col_stud += act_res;
                }
                else if (room_tp == "Comfort")
                {
                    poss_res = 2;
                    ct_liv = 600;//вартість
                    if (stud < stud1)
                    {
                        act_res = r.Next(1, 2);//фактичних мешканців(от 1 до 2)
                        if (act_res == 1)
                        {
                            temp = r.Next(10000000, 99999999);
                            arr_id[0] = temp.ToString();
                            n_income += ct_liv;
                        }//ідентифікатори
                        else if (act_res == 2) for (int i = 0; i < 2; i++)
                            {
                                temp = r.Next(10000000, 99999999);
                                arr_id[i] = temp.ToString();
                                n_income += ct_liv * 2;
                            };
                    }
                    else act_res = 0;//фактичних мешканців(= 0)
                    col_stud += act_res;
                }
                else if (room_tp == "Single")
                {
                    poss_res = 1;
                    ct_liv = 800;//вартість
                    if (stud < stud1)
                    {
                        act_res = 1;//фактичних мешканців - 1

                        temp = r.Next(10000000, 99999999);
                        arr_id[0] = temp.ToString(); //ідентифікатори
                        n_income += ct_liv;
                    }
                    else act_res = 0;//фактичних мешканців - 0
                    col_stud += act_res;
                }

            }
            


        }
        public class Student
        {
            //імя, призвіще, по-батькові, факультет, стать, група
            public string name, surname, patron, faculty, sex, group;
            public string pass_id;//passbook identifier(ідентифікатор залікової книжки)
            public string course;//курс
            public Student(int sex1, string id)//string name1, string surname, string patron, string faculty, string sex, string group, string pass_id, uint course)
            {
                int temp;
                if (sex1 == 1) {
                    temp = r.Next(0,9);
                    sex = "Male";//cтать
                    name = male_names[temp];//імя
                }
                else if (sex1 == 2)
                {
                    temp = r.Next(0, 9);
                    sex = "Female";//cтать
                    name = female_names[temp];//імя
                }
                temp = r.Next(0, 19);
                surname = m_f_surnames[temp];//Прізвище
                temp = r.Next(0, 5);
                patron = patronymic[temp];//По-батькові
                temp = r.Next(0, 4);
                faculty = n_faculty[temp];//Факультет
                temp = r.Next(0, 4);
                group = n_group[temp];//назва групи
                pass_id = id;
                temp = r.Next(0, 4);
                course = n_course[temp];//номер курсу
            }

        }

        public class Worker
        {
            public string name, surname;//імя, прізвище
            public string position;//посада
            public int salary;//заробітна плата
            public string ind_t_num;//individual tax number(індивідуальний податковий номер)
            public Worker()
            {
                long temp;
                temp = r.Next(0, 6);
                name = female_names[temp];//імя
                temp = r.Next(0, 19);
                surname = m_f_surnames[temp];//Прізвище
                temp = r.Next(0, 3);
                position = posit[temp];//Посада
                salary = r.Next(8000, 40000);//заробітня плата
                temp = r.Next(1000000000, 1999999999);
                ind_t_num = temp.ToString();
            }
        }
        public class Univers// : ICloneable
        {
            public string univer_name;// { get; set; } //Назва університету

            public string address;// { get; set; } // адрес

            public int number_of_rooms;// { get; set; } // кількість кімнат
            public List<Room> rooms = new List<Room>();

            public int number_of_staff;// { get; set; } // кількість персоналу
            public List<Worker> workers = new List<Worker>();

            public int number_of_students;// { get; set; } // кількість студентів
            public Dictionary<int, Student> students = new Dictionary<int, Student>();
            public int fact_number_of_st;

            public int income;// дохід за мешкання студентів у гуртожитку, за місяць
            
            public Univers(string un1, string un2, int un4, int un5, int un6)//конструктор
            {
                univer_name = un1;
                address = un2;
                Number_of_rooms = un4;//un4 - кількість кімнат
                Number_of_staff = un5;//un5 - кількість персоналу
                Number_of_students = un6;//кількість студентів

                int temp;
                for (int i = 0; i < number_of_rooms; i++)
                {
                    rooms.Add(new Room(col_stud, number_of_rooms) { });//un6 - тип кімнати
                    //Room room = rooms[i];
                    //col_stud += room.act_res;
                }
                for (int i = 0; i < number_of_rooms; i++)
                {
                    Room room = rooms[i];
                    temp = r.Next(1, 2);
                    for (int j = 0; j < room.act_res; j++)
                    {
                        //students.Add(room.arr_id[j], new Student(temp, room.arr_id[j]));
                        students.Add(id_diction++, new Student(temp, room.arr_id[j]) { });
                    }
                }
                for (int i = 0; i < number_of_staff; i++)
                {
                    workers.Add(new Worker() { });
                }

            }

            public new string ToString()
            {
                string tostring;
               // Room room = rooms[0];
                tostring = "Назва Університету: " + univer_name + ";" +
                    " oooooooooooooooooooooooooooooooooo " + "Адреса: " + address + ";" +
                    " oooooooooooooooooooooooooooooooooo " + "Кількість кімнат: " + number_of_rooms + ";" +
                    " oooooooooooooooooooooooooooooooooo " + "Кількість персоналу: " + number_of_staff + ";" +
                    " oooooooooooooooooooooooooooooooooo " + "Кількість студентів на поселення: " + number_of_students + ";" +
                    " oooooooooooooooooooooooooooooooooo " + "Кількість фактично проживающих: " + fact_number_of_st + ";" +
                    " oooooooooooooooooooooooooooooooooo " + "Дохід за місяць: " + income + ".";
                return tostring;
            }
            public void Method1(int un1) //Збільшити кількість кімнат на un1
            {
                number_of_rooms += un1;
            }
            public void Method2(int un1, int un2) //Збільшити кількість кімнат на un1
            {
                if (un1 == 1) number_of_students += un2;
                else number_of_students -= un2;
            }
            public void Method3(int un1, int un2) //Збільшити кількість кімнат на un1
            {
                
            }
            public int Number_of_rooms
            {
                get => this.number_of_rooms;
                set => this.number_of_rooms = value;
            }
            public int Number_of_staff
            {
                get => this.number_of_staff;
                set => this.number_of_staff = value;
            }
            public int Number_of_students
            {
                get => this.number_of_students;
                set => this.number_of_students = value;
            }

        }
        public Form1()
        {
            InitializeComponent();
            string folderName = @"D:\CampusData";
            DirectoryInfo drInfo = new DirectoryInfo(folderName);
            drInfo.Create();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox4.Text != "" && textBox6.Text != ""
                && textBox7.Text != "" && textBox14.Text != "")
            {
                int uni4 = Convert.ToInt32(textBox6.Text);//кількість кімнат
                int uni5 = Convert.ToInt32(textBox7.Text);//кількість співробітників
                int uni6 = Convert.ToInt32(textBox14.Text);//кількість співробітників
                
                if (uni4 > 30 && uni5 > 10)
                {
                    string uni1, uni2;//, uni6;
                    //int uni3;
                    uni1 = textBox3.Text;//Назва Університету
                    uni2 = textBox4.Text;//Адреса Університету
                    //uni6 = listBox1.SelectedItem.ToString();//тип кімнати

                    //uni3 = Convert.ToInt32(textBox5.Text);//Дохід за мешкання за місяць

                    univer[Kol] = new Univers(uni1, uni2, uni4, uni5, uni6);
                    univer[Kol].income = n_income;
                    univer[Kol++].fact_number_of_st = col_stud;
                    n_income = 0;
                    id_diction = 0;
                    col_stud = 0;
                   // univer[Kol++].get_numbers();
                    //очистити бокси
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox14.Text = "";
                }
                else
                {
                    MessageBox.Show("Кількість кімнат повинна бути більше 30, а кількість співробітників більше 10!", "Form Closing",
                                MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question);
                }
            }
            
        }

        //Показати інформацію по Університету
        public void button2_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(textBox1.Text);
            if (i >= 0 && i <= Kol-1)
            {
                textBox2.Text = "";
                textBox2.Text = univer[i].ToString();//виведення інформації
            }
            else {
                textBox2.Text = "";
            }
        }

        //Заселення/виселення одного студенту
        private void button4_Click(object sender, EventArgs e)
        {
            int i1 = Convert.ToInt32(textBox8.Text);//Заселення - 1, Виселення - 2
            int i2 = Convert.ToInt32(textBox9.Text);//який універ
            int i3 = Convert.ToInt32(textBox10.Text);//кількість студентів
            if ((i1 == 1 || i1 == 2) && (i2 >= 0 && i2 <= Kol - 1) && i3 >= 1)
            {
                univer[i2].Method2(i1, i3);
            }
            else
            {
                MessageBox.Show("Невірно введені дані!", "Form Closing",
                                MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question);
            }
        }

       
        private void button6_Click(object sender, EventArgs e)
        {
            int i1 = Convert.ToInt32(textBox12.Text);//номер університету
            textBox13.Text = "";
            textBox13.Text = "Назва Університету: " + univer[i1].univer_name + ";" +
                    " oooooooooooooooooooooooooooooooooo " + "Дохід за місяць: " + univer[i1].income + ";" +
                    " oooooooooooooooooooooooooooooooooo " + "Дохід за півроку: " + univer[i1].income * 6 + ";" +
                    " oooooooooooooooooooooooooooooooooo " + "Дохід за рік: " + univer[i1].income * 12 + ";";//виведення інформації
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //string path = @"D:\CampusData\Data.txt";
            int i1 = Convert.ToInt32(textBox5.Text);//номер університету

            try
            {
                // Create the file, or overwrite if the file exists.
                using (FileStream fs = File.Create(@"D:\CampusData\Data.txt"))
                {
                    StreamWriter w = new StreamWriter(fs, Encoding.Default);
                    w.WriteLine("Назва Університету: " + univer[i1].univer_name + ";");
                    w.WriteLine("Адреса: " + univer[i1].address + ";");
                    w.WriteLine("Кількість кімнат: " + univer[i1].number_of_rooms + ";");
                    w.WriteLine("Кількість персоналу: " + univer[i1].number_of_staff + ";");
                    w.WriteLine("Кількість студентів на поселення: " + univer[i1].number_of_students + ";");
                    w.WriteLine("Кількість фактично проживающих: " + univer[i1].fact_number_of_st + ";");
                    w.WriteLine("Дохід за місяць: " + univer[i1].income + ".");
                    w.Close();
                }
                using (FileStream fs = File.Create(@"D:\CampusData\Rooms.txt"))
                {
                    StreamWriter w = new StreamWriter(fs, Encoding.Default);
                    for(int i = 0; i < univer[i1].number_of_rooms; i++)
                    {
                        //Room room = rooms[i];
                        w.WriteLine("Кімната №" + i);
                        w.WriteLine("Номер кімнати: " + univer[i1].rooms[i].unq_nmb);
                        w.WriteLine("Кількість можливих мешканців: " + univer[i1].rooms[i].poss_res);
                        w.WriteLine("Кількість фактичних мешканців: " + univer[i1].rooms[i].act_res);
                        w.WriteLine("Вартість проживання: " + univer[i1].rooms[i].ct_liv);
                        w.WriteLine("Тип кімнати: " + univer[i1].rooms[i].room_tp);
                        w.WriteLine("----------------------------------------------");

                    }
                    w.Close();
                }
                using (FileStream fs = File.Create(@"D:\CampusData\Student.txt"))
                {
                    StreamWriter w = new StreamWriter(fs, Encoding.Default);
                    for (int i = 0; i < univer[i1].fact_number_of_st; i++)
                    {
                        w.WriteLine("Прізвище - " +univer[i1].students[i].name);
                        w.WriteLine("Імя - " + univer[i1].students[i].surname);
                        w.WriteLine("По-батькові - " + univer[i1].students[i].patron);
                        w.WriteLine("Факультет - " + univer[i1].students[i].faculty);
                        w.WriteLine("Стать - " + univer[i1].students[i].sex);
                        w.WriteLine("Група - " + univer[i1].students[i].group);
                        w.WriteLine("Ідентифікатор - " + univer[i1].students[i].pass_id);
                        w.WriteLine("Курс - " + univer[i1].students[i].course);
                        w.WriteLine("----------------------------------------------");

                    }
                    w.Close();
                }
                using (FileStream fs = File.Create(@"D:\CampusData\Worker.txt"))
                {
                    StreamWriter w = new StreamWriter(fs, Encoding.Default);
                    for (int i = 0; i < univer[i1].number_of_staff; i++)
                    {
                        w.WriteLine("Прізвище - " + univer[i1].workers[i].name);
                        w.WriteLine("Імя - " + univer[i1].workers[i].surname);
                        w.WriteLine("Посада - " + univer[i1].workers[i].position);
                        w.WriteLine("Заробітня плата - " + univer[i1].workers[i].salary);
                        w.WriteLine("Податковий номер - " + univer[i1].workers[i].ind_t_num);
                        w.WriteLine("----------------------------------------------");

                    }
                    w.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Form Closing",
                               MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question);
            }
        }
    }
}
