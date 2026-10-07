namespace lamia12771.Migrations
{
    using lamia12771.Models;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration
        : DbMigrationsConfiguration<lamia12771.Models.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(
            lamia12771.Models.SchoolContext context
        )
        {
            /* =========================================================
               ROOMS
               Default rooms are added ONLY if missing.
               Existing rooms are never overwritten.
               ========================================================= */

            var defaultRooms = new[]
            {
                new Room
                {
                    RoomNumber = "LH-01",
                    RoomName = "Lecture Hall",
                    RoomType = "Lecture Hall",
                    Capacity = 180,
                    Area = 420,
                    Status = "Available",

                    Description =
                        "A modern lecture hall designed for large classes, academic presentations, seminars, and university events.",

                    Facilities =
                        "Projector|" +
                        "Large Display|" +
                        "Audio System|" +
                        "Stage|" +
                        "Wi-Fi|" +
                        "Air Conditioning",

                    ImagePath =
                        "/images/rooms/Lecture Hall.png"
                },


                new Room
                {
                    RoomNumber = "CL-01",
                    RoomName = "Computer Lab",
                    RoomType = "Computer Lab",
                    Capacity = 30,
                    Area = 115,
                    Status = "Available",

                    Description =
                        "A modern computer laboratory designed for programming, software development, digital learning, and practical technology courses.",

                    Facilities =
                        "Computers|" +
                        "High-Speed Internet|" +
                        "Projector|" +
                        "Development Software|" +
                        "Wi-Fi|" +
                        "Air Conditioning",

                    ImagePath =
                        "/images/rooms/Computer Lab.png"
                },


                new Room
                {
                    RoomNumber = "AL-01",
                    RoomName = "Anatomy Lab",
                    RoomType = "Laboratory",
                    Capacity = 25,
                    Area = 95,
                    Status = "In Use",

                    Description =
                        "A specialized anatomy laboratory equipped with anatomical models and educational resources for practical study and scientific learning.",

                    Facilities =
                        "Anatomical Models|" +
                        "Skeleton Models|" +
                        "Display Units|" +
                        "Study Stations|" +
                        "Lighting|" +
                        "Storage",

                    ImagePath =
                        "/images/rooms/Anatomy Lab.png"
                },


                new Room
                {
                    RoomNumber = "BL-01",
                    RoomName = "Biology Lab",
                    RoomType = "Laboratory",
                    Capacity = 24,
                    Area = 100,
                    Status = "Available",

                    Description =
                        "A biology laboratory designed for practical experiments, microscope work, scientific observation, and laboratory-based learning.",

                    Facilities =
                        "Microscopes|" +
                        "Lab Stations|" +
                        "Scientific Equipment|" +
                        "Sink Stations|" +
                        "Storage|" +
                        "Safety Equipment",

                    ImagePath =
                        "/images/rooms/Biology Lab.png"
                },


                new Room
                {
                    RoomNumber = "LIB-01",
                    RoomName = "University Library",
                    RoomType = "Library",
                    Capacity = 120,
                    Area = 650,
                    Status = "Available",

                    Description =
                        "A spacious university library providing a quiet academic environment for reading, research, individual study, and collaborative learning.",

                    Facilities =
                        "Books|" +
                        "Study Areas|" +
                        "Research Desks|" +
                        "Wi-Fi|" +
                        "Reading Spaces|" +
                        "Reference Resources",

                    ImagePath =
                        "/images/rooms/University Library.png"
                },


                new Room
                {
                    RoomNumber = "MR-01",
                    RoomName = "Meeting Room",
                    RoomType = "Meeting Room",
                    Capacity = 16,
                    Area = 55,
                    Status = "In Use",

                    Description =
                        "A professional meeting room designed for faculty meetings, project discussions, presentations, and administrative collaboration.",

                    Facilities =
                        "Conference Table|" +
                        "Presentation Screen|" +
                        "Wi-Fi|" +
                        "Video Conferencing|" +
                        "Power Outlets|" +
                        "Air Conditioning",

                    ImagePath =
                        "/images/rooms/Meeting Room.png"
                }
            };


            foreach (var defaultRoom in defaultRooms)
            {
                bool roomExists =
                    context.Rooms.Any(
                        r =>
                            r.RoomNumber ==
                            defaultRoom.RoomNumber
                    );


                if (!roomExists)
                {
                    context.Rooms.Add(
                        defaultRoom
                    );
                }
            }


            /* =========================================================
               REMOVE OLD COURSES
               نحذف فقط المواد القديمة من المشروع القديم
               ========================================================= */

            string[] oldCourseCodes =
            {
                "CS 201",
                "CS 340",
                "BIO 204",
                "BIO 310",
                "MEE 220",
                "BUS 150"
            };


            var oldCourses =
                context.Courses
                    .Where(
                        c =>
                            oldCourseCodes.Contains(
                                c.CourseCode
                            )
                    )
                    .ToList();


            if (oldCourses.Any())
            {
                context.Courses.RemoveRange(
                    oldCourses
                );

                context.SaveChanges();
            }


            /* =========================================================
               DEFAULT COURSES

               IMPORTANT:
               Add default courses ONLY if they do not already exist.

               Existing courses are NEVER overwritten.
               ========================================================= */

            var defaultCourses = new[]
            {
                new Course
                {
                    CourseCode = "CHEM 210",
                    CourseName = "Analytical Chemistry",
                    Category = "Chemistry",
                    CreditHours = 4,
                    Schedule = "Mon & Wed, 9:00–10:30 AM",
                    Location = "Chemistry Lab C205",

                    Description =
                        "An applied study of qualitative and quantitative chemical analysis, laboratory measurement, instrumental methods, and accurate interpretation of experimental results.",

                    Topics =
                        "Laboratory Safety & Measurement|" +
                        "Acid-Base Titration|" +
                        "Spectrophotometry|" +
                        "Chromatography|" +
                        "Electrochemical Analysis|" +
                        "Quality Control",

                    ImagePath =
                        "/images/courses/analytical-chemistry.jpg",

                    Instructor = null
                },


                new Course
                {
                    CourseCode = "CS 350",
                    CourseName = "Artificial Intelligence",
                    Category = "Computer Science",
                    CreditHours = 3,
                    Schedule = "Tue & Thu, 1:00–2:30 PM",
                    Location = "AI Computing Lab C120",

                    Description =
                        "An introduction to artificial intelligence methods used to build intelligent systems, including search, machine learning, neural networks, and responsible AI applications.",

                    Topics =
                        "Search & Problem Solving|" +
                        "Knowledge Representation|" +
                        "Machine Learning|" +
                        "Neural Networks|" +
                        "Computer Vision|" +
                        "Responsible AI",

                    ImagePath =
                        "/images/courses/artificial-intelligence.jpg",

                    Instructor = null
                },


                new Course
                {
                    CourseCode = "BIO 315",
                    CourseName = "Biotechnology",
                    Category = "Biology",
                    CreditHours = 4,
                    Schedule = "Mon, Wed & Fri, 11:00–11:50 AM",
                    Location = "Biotechnology Lab B215",

                    Description =
                        "A laboratory-focused course exploring the use of cells, biological systems, and molecular techniques in biotechnology, research, and modern bioprocessing.",

                    Topics =
                        "Cell Culture|" +
                        "Recombinant DNA|" +
                        "Bioreactors|" +
                        "Protein Expression|" +
                        "Bioprocessing|" +
                        "Bioethics",

                    ImagePath =
                        "/images/courses/biotechnology.jpg",

                    Instructor = null
                },


                new Course
                {
                    CourseCode = "BIO 330",
                    CourseName = "Neuroscience",
                    Category = "Biology",
                    CreditHours = 3,
                    Schedule = "Sun & Tue, 10:00–11:30 AM",
                    Location = "Anatomy Lab B310",

                    Description =
                        "A study of the structure and function of the nervous system, with emphasis on neurons, brain anatomy, sensory processing, motor control, and neural adaptation.",

                    Topics =
                        "Neuron Structure|" +
                        "Synaptic Transmission|" +
                        "Brain Anatomy|" +
                        "Sensory Systems|" +
                        "Motor Control|" +
                        "Neuroplasticity",

                    ImagePath =
                        "/images/courses/neuroscience.jpg",

                    Instructor = null
                },


                new Course
                {
                    CourseCode = "MEE 260",
                    CourseName = "Engineering Systems",
                    Category = "Engineering",
                    CreditHours = 3,
                    Schedule = "Mon & Wed, 1:00–2:30 PM",
                    Location = "Engineering Systems Lab E220",

                    Description =
                        "An engineering course focused on integrated technical systems, instrumentation, control, testing, and the interaction between mechanical and electronic components.",

                    Topics =
                        "Systems Thinking|" +
                        "Sensors & Instrumentation|" +
                        "Control Systems|" +
                        "Thermal Systems|" +
                        "System Integration|" +
                        "Testing & Reliability",

                    ImagePath =
                        "/images/courses/engineering-systems.jpg",

                    Instructor = null
                },


                new Course
                {
                    CourseCode = "GEO 120",
                    CourseName = "World Geography",
                    Category = "Geography",
                    CreditHours = 3,
                    Schedule = "Tue & Thu, 10:00–11:30 AM",
                    Location = "Humanities Hall H105",

                    Description =
                        "A broad introduction to world geography through maps, physical environments, climate, population, culture, economic regions, and global spatial relationships.",

                    Topics =
                        "Maps & Coordinates|" +
                        "Physical Geography|" +
                        "Climate Regions|" +
                        "Population & Culture|" +
                        "Economic Geography|" +
                        "Global Connections",

                    ImagePath =
                        "/images/courses/world-geography.jpg",

                    Instructor = null
                }
            };


            foreach (var defaultCourse in defaultCourses)
            {
                bool courseExists =
                    context.Courses.Any(
                        c =>
                            c.CourseCode ==
                            defaultCourse.CourseCode
                    );


                if (!courseExists)
                {
                    context.Courses.Add(
                        defaultCourse
                    );
                }
            }


            /* =========================================================
               DEFAULT STUDENTS

               IMPORTANT:
               Students are added ONLY if their email does not already
               exist. Existing student records are NEVER overwritten.
               ========================================================= */

            var saraAdvisor =
                context.Teachers.FirstOrDefault(
                    t => t.Name == "Dr. James Bennett"
                );

            var yusufAdvisor =
                context.Teachers.FirstOrDefault(
                    t => t.Name == "Dr. Sara Al-Harbi"
                );

            var mariamAdvisor =
                context.Teachers.FirstOrDefault(
                    t => t.Name == "Dr. Daniel Foster"
                );

            var fatimaAdvisor =
                context.Teachers.FirstOrDefault(
                    t => t.Name == "Dr. Faisal Al-Dosari"
                );

            var lamiaAdvisor =
                context.Teachers.FirstOrDefault(
                    t => t.Name == "Dr. Sara Al-Harbi"
                );


            var defaultStudents = new[]
            {
                new Student
                {
                    Name = "Sara Mohammed",
                    Age = 22,
                    Major = "Software Engineering",
                    Level = "Level 7",
                    GPA = 4.60m,
                    CreditsCompleted = 96,
                    DegreeProgress = 80,
                    AcademicStanding = "Dean's List",
                    Email = "sara.mohammed@student.aurelia.edu",
                    ImagePath = "/images/students/sara-mohammed.png",

                    TeacherId =
                        saraAdvisor == null
                            ? (int?)null
                            : saraAdvisor.TeacherId
                },


                new Student
                {
                    Name = "Yusuf Karim",
                    Age = 21,
                    Major = "Computer Science",
                    Level = "Level 5",
                    GPA = 3.90m,
                    CreditsCompleted = 68,
                    DegreeProgress = 57,
                    AcademicStanding = "Good Standing",
                    Email = "yusuf.karim@student.aurelia.edu",
                    ImagePath = "/images/students/yusuf-karim.png",

                    TeacherId =
                        yusufAdvisor == null
                            ? (int?)null
                            : yusufAdvisor.TeacherId
                },


                new Student
                {
                    Name = "Mariam El-Sayed",
                    Age = 22,
                    Major = "Biology",
                    Level = "Level 6",
                    GPA = 4.20m,
                    CreditsCompleted = 82,
                    DegreeProgress = 68,
                    AcademicStanding = "Dean's List",
                    Email = "mariam.elsayed@student.aurelia.edu",
                    ImagePath = "/images/students/mariam-el-sayed.png",

                    TeacherId =
                        mariamAdvisor == null
                            ? (int?)null
                            : mariamAdvisor.TeacherId
                },


                new Student
                {
                    Name = "Adam Wilson",
                    Age = 20,
                    Major = "Business Administration",
                    Level = "Level 4",
                    GPA = 3.50m,
                    CreditsCompleted = 52,
                    DegreeProgress = 43,
                    AcademicStanding = "Good Standing",
                    Email = "Adam.wilson@student.aurelia.edu",
                    ImagePath = "/images/students/daniel-osei.png",

                    // There is currently no Business faculty member.
                    TeacherId = null
                },


                new Student
                {
                    Name = "Fatima Al-Rashid",
                    Age = 23,
                    Major = "Mechanical Engineering",
                    Level = "Level 6",
                    GPA = 3.80m,
                    CreditsCompleted = 88,
                    DegreeProgress = 73,
                    AcademicStanding = "Good Standing",
                    Email = "fatima.alrashid@student.aurelia.edu",
                    ImagePath = "/images/students/fatima-al-rashid.png",

                    TeacherId =
                        fatimaAdvisor == null
                            ? (int?)null
                            : fatimaAdvisor.TeacherId
                },


                new Student
                {
                    Name = "Lana  Alanazi",
                    Age = 22,
                    Major = "Software Engineering",
                    Level = "Level 8",
                    GPA = 4.40m,
                    CreditsCompleted = 112,
                    DegreeProgress = 93,
                    AcademicStanding = "Dean's List",
                    Email = "lana.alanazi@student.aurelia.edu",
                    ImagePath = "/images/students/lamia-mohammed-alanazi.png",

                    TeacherId =
                        lamiaAdvisor == null
                            ? (int?)null
                            : lamiaAdvisor.TeacherId
                }
            };


            foreach (var defaultStudent in defaultStudents)
            {
                bool studentExists =
                    context.Students.Any(
                        s =>
                            s.Email ==
                            defaultStudent.Email
                    );


                if (!studentExists)
                {
                    context.Students.Add(
                        defaultStudent
                    );
                }
            }


            /* =========================================================
               SAVE
               ========================================================= */

            context.SaveChanges();
        }
    }
}
