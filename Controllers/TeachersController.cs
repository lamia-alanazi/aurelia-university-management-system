using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using lamia12771.Models;
using lamia12771.Filters;

namespace lamia12771.Controllers
{
    public class TeachersController : Controller
    {
        private SchoolContext db = new SchoolContext();


        // Display teachers list

        public ActionResult Index()
        {
            SeedTeachersIfEmpty();

            RenameDefaultTeachers();

            RenameSelectedTeachersToInternational();

            UpdateMichaelBennettToJames();

            UpdateEmmaToGeography();

            AddDefaultOffices();

            AddDefaultProfiles();



            ViewBag.AssignedCourses =
                db.Courses
                  .Where(c => c.TeacherId != null)
                  .OrderBy(c => c.CourseCode)
                  .ToList();


            return View(
                db.Teachers
                  .OrderBy(t => t.Name)
                  .ToList()
            );
        }


        // Add default teachers if the table is empty

        private void SeedTeachersIfEmpty()
        {
            if (db.Teachers.Any())
            {
                return;
            }


            db.Teachers.AddRange(new[]
            {
                // SARA AL-HARBI profile

                new Teacher
                {
                    Name = "Dr. Sara Al-Harbi",

                    Subject = "Computer Science",

                    Office = "C220",

                    Title = "Associate Professor",

                    About =
                        "Dr. Sara Al-Harbi specializes in artificial intelligence, " +
                        "machine learning, and intelligent software systems. " +
                        "Her academic work focuses on applying modern computing " +
                        "techniques to practical and educational challenges.",

                    Education =
                        "Ph.D. in Computer Science, University of Manchester|" +
                        "M.Sc. in Artificial Intelligence, King Saud University|" +
                        "B.Sc. in Computer Science, King Saud University",

                    AcademicExperience =
                        "Associate Professor, Aurelia University (2022–Present)|" +
                        "Assistant Professor, Aurelia University (2018–2022)|" +
                        "Research Fellow in Artificial Intelligence (2016–2018)",

                    ResearchInterests =
                        "Artificial Intelligence|" +
                        "Machine Learning|" +
                        "Intelligent Systems|" +
                        "Data Science",

                    CoursesTaught =
                        "CS 350 — Artificial Intelligence|" +
                        "CS 320 — Machine Learning|" +
                        "CS 210 — Programming Fundamentals",

                    Email =
                        "sara.alharbi@aurelia.edu",

                    ImagePath =
                        null
                },


                // DANIEL FOSTER profile

                new Teacher
                {
                    Name = "Dr. Daniel Foster",

                    Subject = "Biology",

                    Office = "B108",

                    Title = "Associate Professor",

                    About =
                        "Dr. Daniel Foster teaches and researches modern biological " +
                        "sciences with an emphasis on biotechnology, cellular biology, " +
                        "and molecular processes. His work connects laboratory research " +
                        "with practical applications in life sciences.",

                    Education =
                        "Ph.D. in Molecular Biology, University of Edinburgh|" +
                        "M.Sc. in Biotechnology, King Abdulaziz University|" +
                        "B.Sc. in Biological Sciences, King Abdulaziz University",

                    AcademicExperience =
                        "Associate Professor, Aurelia University (2021–Present)|" +
                        "Assistant Professor of Biology (2017–2021)|" +
                        "Molecular Biology Researcher (2014–2017)",

                    ResearchInterests =
                        "Biotechnology|" +
                        "Molecular Biology|" +
                        "Cell Biology|" +
                        "Genetics",

                    CoursesTaught =
                        "BIO 315 — Biotechnology|" +
                        "BIO 220 — Molecular Biology|" +
                        "BIO 110 — General Biology",

                    Email =
                        "daniel.foster@aurelia.edu",

                    ImagePath =
                        null
                },


                // EMMA COLLINS profile

                new Teacher
                {
                    Name = "Dr. Emma Collins",

                    Subject = "Business",

                    Office = "D302",

                    Title = "Assistant Professor",

                    About =
                        "Dr. Emma Collins focuses on business strategy, organizational " +
                        "management, and entrepreneurship. Her teaching combines business " +
                        "theory with practical decision-making and modern management methods.",

                    Education =
                        "Ph.D. in Business Administration, University of Leeds|" +
                        "MBA, King Saud University|" +
                        "B.Sc. in Business Administration, Princess Nourah University",

                    AcademicExperience =
                        "Assistant Professor, Aurelia University (2020–Present)|" +
                        "Business Strategy Lecturer (2017–2020)|" +
                        "Management Consultant (2014–2017)",

                    ResearchInterests =
                        "Business Strategy|" +
                        "Entrepreneurship|" +
                        "Organizational Management|" +
                        "Leadership",

                    CoursesTaught =
                        "BUS 310 — Strategic Management|" +
                        "BUS 220 — Organizational Behavior|" +
                        "BUS 101 — Introduction to Business",

                    Email =
                        "emma.collins@aurelia.edu",

                    ImagePath =
                        null
                },


                // FAISAL AL-DOSARI profile

                new Teacher
                {
                    Name = "Dr. Faisal Al-Dosari",

                    Subject = "Engineering",

                    Office = "E210",

                    Title = "Professor",

                    About =
                        "Dr. Faisal Al-Dosari specializes in mechanical and engineering " +
                        "systems. His academic interests include system design, energy " +
                        "efficiency, and the development of reliable engineering solutions.",

                    Education =
                        "Ph.D. in Mechanical Engineering, University of Sheffield|" +
                        "M.Sc. in Engineering Systems, King Fahd University of Petroleum and Minerals|" +
                        "B.Sc. in Mechanical Engineering, King Fahd University of Petroleum and Minerals",

                    AcademicExperience =
                        "Professor, Aurelia University (2023–Present)|" +
                        "Associate Professor of Engineering (2018–2023)|" +
                        "Senior Engineering Researcher (2014–2018)",

                    ResearchInterests =
                        "Engineering Systems|" +
                        "Mechanical Design|" +
                        "Energy Efficiency|" +
                        "Automation",

                    CoursesTaught =
                        "MEE 260 — Engineering Systems|" +
                        "MEE 240 — Mechanical Design|" +
                        "ENG 120 — Engineering Fundamentals",

                    Email =
                        "faisal.aldosari@aurelia.edu",

                    ImagePath =
                        null
                },


                // NORA AL-ANAZI profile

                new Teacher
                {
                    Name = "Dr. Nora Al-Anazi",

                    Subject = "Mathematics",

                    Office = "A115",

                    Title = "Associate Professor",

                    About =
                        "Dr. Nora Al-Anazi teaches applied and theoretical mathematics. " +
                        "Her work focuses on mathematical modeling, numerical methods, " +
                        "and the use of mathematics to solve scientific and engineering problems.",

                    Education =
                        "Ph.D. in Applied Mathematics, University of Birmingham|" +
                        "M.Sc. in Mathematics, King Saud University|" +
                        "B.Sc. in Mathematics, Princess Nourah University",

                    AcademicExperience =
                        "Associate Professor, Aurelia University (2021–Present)|" +
                        "Assistant Professor of Mathematics (2017–2021)|" +
                        "Mathematics Lecturer (2014–2017)",

                    ResearchInterests =
                        "Applied Mathematics|" +
                        "Mathematical Modeling|" +
                        "Numerical Analysis|" +
                        "Statistics",

                    CoursesTaught =
                        "MATH 310 — Applied Mathematics|" +
                        "MATH 220 — Differential Equations|" +
                        "MATH 110 — Calculus",

                    Email =
                        "nora.alanazi@aurelia.edu",

                    ImagePath =
                        null
                },


                // JAMES BENNETT profile

                new Teacher
                {
                    Name = "Dr. James Bennett",

                    Subject = "Computer Science",

                    Office = "C214",

                    Title = "Associate Professor",

                    About =
                        "Dr. James Bennett specializes in software systems, databases, " +
                        "and cloud computing. His research focuses on scalable applications, " +
                        "reliable information systems, and modern software architecture.",

                    Education =
                        "Ph.D. in Computer Science, University of Toronto|" +
                        "M.Sc. in Computer Science, King Fahd University of Petroleum and Minerals|" +
                        "B.Sc. in Computer Science, King Saud University",

                    AcademicExperience =
                        "Associate Professor, Aurelia University (2019–Present)|" +
                        "Assistant Professor of Computer Science (2016–2019)|" +
                        "Software Systems Researcher (2013–2016)",

                    ResearchInterests =
                        "Distributed Systems|" +
                        "Cloud Computing|" +
                        "Database Systems|" +
                        "Software Architecture",

                    CoursesTaught =
                        "CS 340 — Database Systems|" +
                        "CS 330 — Cloud Computing|" +
                        "CS 220 — Data Structures",

                    Email =
                        "james.bennett@aurelia.edu",

                    ImagePath =
                        null
                }
            });


            db.SaveChanges();
        }


        // Update old sample teacher names

        private void RenameDefaultTeachers()
        {
            bool changed = false;


            var teacher =
                db.Teachers.FirstOrDefault(
                    t => t.Name == "Dr. Amara Osei"
                );

            if (teacher != null)
            {
                teacher.Name =
                    "Dr. Sara Al-Harbi";

                changed = true;
            }


            teacher =
                db.Teachers.FirstOrDefault(
                    t => t.Name == "Dr. Elias Vance"
                );

            if (teacher != null)
            {
                teacher.Name =
                    "Dr. Daniel Foster";

                changed = true;
            }


            teacher =
                db.Teachers.FirstOrDefault(
                    t => t.Name == "Dr. Priya Nair"
                );

            if (teacher != null)
            {
                teacher.Name =
                    "Dr. Emma Collins";

                changed = true;
            }


            teacher =
                db.Teachers.FirstOrDefault(
                    t => t.Name == "Dr. Marcus Feld"
                );

            if (teacher != null)
            {
                teacher.Name =
                    "Dr. Faisal Al-Dosari";

                changed = true;
            }


            teacher =
                db.Teachers.FirstOrDefault(
                    t => t.Name == "Dr. Layla Haddad"
                );

            if (teacher != null)
            {
                teacher.Name =
                    "Dr. Nora Al-Anazi";

                changed = true;
            }


            teacher =
                db.Teachers.FirstOrDefault(
                    t => t.Name == "Dr. Noah Bergstrom"
                );

            if (teacher != null)
            {
                teacher.Name =
                    "Dr. James Bennett";

                changed = true;
            }


            if (changed)
            {
                db.SaveChanges();
            }
        }


        // Update selected teacher profiles

        private void RenameSelectedTeachersToInternational()
        {
            bool changed = false;


            // =====================================================
            // OMAR -> DANIEL
            // =====================================================

            var teacher =
                db.Teachers.FirstOrDefault(
                    t =>
                        t.Name == "Dr. Omar Al-Qahtani" &&
                        t.Subject == "Biology"
                );


            if (teacher != null)
            {
                teacher.Name =
                    "Dr. Daniel Foster";


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.Email
                    ) ||
                    teacher.Email ==
                    "omar.alqahtani@aurelia.edu"
                )
                {
                    teacher.Email =
                        "daniel.foster@aurelia.edu";
                }


                if (
                    !string.IsNullOrWhiteSpace(
                        teacher.About
                    )
                )
                {
                    teacher.About =
                        teacher.About.Replace(
                            "Dr. Omar Al-Qahtani",
                            "Dr. Daniel Foster"
                        );
                }


                changed = true;
            }


            // =====================================================
            // REEM -> EMMA
            // =====================================================

            teacher =
                db.Teachers.FirstOrDefault(
                    t =>
                        t.Name == "Dr. Reem Al-Mutairi" &&
                        t.Subject == "Business"
                );


            if (teacher != null)
            {
                teacher.Name =
                    "Dr. Emma Collins";


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.Email
                    ) ||
                    teacher.Email ==
                    "reem.almutairi@aurelia.edu"
                )
                {
                    teacher.Email =
                        "emma.collins@aurelia.edu";
                }


                if (
                    !string.IsNullOrWhiteSpace(
                        teacher.About
                    )
                )
                {
                    teacher.About =
                        teacher.About.Replace(
                            "Dr. Reem Al-Mutairi",
                            "Dr. Emma Collins"
                        );
                }


                changed = true;
            }


            // =====================================================
            // KHALID -> JAMES
            // =====================================================

            teacher =
                db.Teachers.FirstOrDefault(
                    t =>
                        t.Name == "Dr. Khalid Al-Shammari" &&
                        t.Subject == "Computer Science"
                );


            if (teacher != null)
            {
                teacher.Name =
                    "Dr. James Bennett";


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.Email
                    ) ||
                    teacher.Email ==
                    "khalid.alshammari@aurelia.edu"
                )
                {
                    teacher.Email =
                        "james.bennett@aurelia.edu";
                }


                if (
                    !string.IsNullOrWhiteSpace(
                        teacher.About
                    )
                )
                {
                    teacher.About =
                        teacher.About.Replace(
                            "Dr. Khalid Al-Shammari",
                            "Dr. James Bennett"
                        );
                }


                changed = true;
            }


            if (changed)
            {
                db.SaveChanges();
            }
        }

        // =========================================================
        // UPDATE DR. MICHAEL BENNETT TO DR. JAMES BENNETT
        // Safety update in case the previous version already renamed him.
        // Keeps TeacherId and ImagePath unchanged, so all Course and
        // Student relationships remain exactly the same.
        // =========================================================

        private void UpdateMichaelBennettToJames()
        {
            var teacher =
                db.Teachers.FirstOrDefault(
                    t => t.Name == "Dr. Michael Bennett"
                );


            if (teacher == null)
            {
                return;
            }


            teacher.Name =
                "Dr. James Bennett";


            teacher.Subject =
                "Computer Science";


            teacher.Office =
                "C214";


            teacher.Title =
                "Associate Professor";


            teacher.About =
                "Dr. James Bennett specializes in software systems, databases, " +
                "and cloud computing. His research focuses on scalable applications, " +
                "reliable information systems, and modern software architecture.";


            teacher.Education =
                "Ph.D. in Computer Science, University of Toronto|" +
                "M.Sc. in Computer Science, King Fahd University of Petroleum and Minerals|" +
                "B.Sc. in Computer Science, King Saud University";


            teacher.AcademicExperience =
                "Associate Professor, Aurelia University (2019–Present)|" +
                "Assistant Professor of Computer Science (2016–2019)|" +
                "Software Systems Researcher (2013–2016)";


            teacher.ResearchInterests =
                "Distributed Systems|" +
                "Cloud Computing|" +
                "Database Systems|" +
                "Software Architecture";


            teacher.CoursesTaught =
                "CS 340 — Database Systems|" +
                "CS 330 — Cloud Computing|" +
                "CS 220 — Data Structures";


            teacher.Email =
                "james.bennett@aurelia.edu";


            // Keep the currently selected teacher image.
            // TeacherId is also unchanged.


            db.SaveChanges();
        }


        // =========================================================
        // UPDATE EMMA FROM BUSINESS TO GEOGRAPHY
        // Runs only while Emma still has the old Business profile
        // =========================================================

        private void UpdateEmmaToGeography()
        {
            var teacher =
                db.Teachers.FirstOrDefault(
                    t => t.Name == "Dr. Emma Collins"
                );


            if (teacher == null)
            {
                return;
            }


            // Skip if the profile was already updated
            if (teacher.Subject == "Geography")
            {
                return;
            }


            // Keep manually updated teacher data
            if (teacher.Subject != "Business")
            {
                return;
            }


            teacher.Subject =
                "Geography";


            teacher.Title =
                "Assistant Professor";


            teacher.About =
                "Dr. Emma Collins specializes in human geography, " +
                "regional studies, geographic analysis, and global development. " +
                "Her teaching explores the relationship between people, places, " +
                "environments, and regions across the world.";


            teacher.Education =
                "Ph.D. in Geography, University of Leeds|" +
                "M.Sc. in Geographic Studies, University of Manchester|" +
                "B.Sc. in Geography, University of Birmingham";


            teacher.AcademicExperience =
                "Assistant Professor of Geography, Aurelia University (2020–Present)|" +
                "Geography Lecturer (2017–2020)|" +
                "Geographic Research Assistant (2014–2017)";


            teacher.ResearchInterests =
                "Human Geography|" +
                "Regional Studies|" +
                "Geographic Information Systems|" +
                "Global Development";


            teacher.CoursesTaught =
                "GEO 120 — World Geography|" +
                "GEO 220 — Human Geography|" +
                "GEO 310 — Regional Studies";


            teacher.Email =
                "emma.collins@aurelia.edu";


            db.SaveChanges();
        }
        // Add default office numbers

        private void AddDefaultOffices()
        {
            bool changed = false;


            var teacher =
                db.Teachers.FirstOrDefault(
                    t => t.Name == "Dr. Sara Al-Harbi"
                );

            if (
                teacher != null &&
                string.IsNullOrWhiteSpace(
                    teacher.Office
                )
            )
            {
                teacher.Office =
                    "C220";

                changed = true;
            }


            teacher =
                db.Teachers.FirstOrDefault(
                    t => t.Name == "Dr. Daniel Foster"
                );

            if (
                teacher != null &&
                string.IsNullOrWhiteSpace(
                    teacher.Office
                )
            )
            {
                teacher.Office =
                    "B108";

                changed = true;
            }


            teacher =
                db.Teachers.FirstOrDefault(
                    t => t.Name == "Dr. Emma Collins"
                );

            if (
                teacher != null &&
                string.IsNullOrWhiteSpace(
                    teacher.Office
                )
            )
            {
                teacher.Office =
                    "D302";

                changed = true;
            }


            teacher =
                db.Teachers.FirstOrDefault(
                    t => t.Name == "Dr. Faisal Al-Dosari"
                );

            if (
                teacher != null &&
                string.IsNullOrWhiteSpace(
                    teacher.Office
                )
            )
            {
                teacher.Office =
                    "E210";

                changed = true;
            }


            teacher =
                db.Teachers.FirstOrDefault(
                    t => t.Name == "Dr. Nora Al-Anazi"
                );

            if (
                teacher != null &&
                string.IsNullOrWhiteSpace(
                    teacher.Office
                )
            )
            {
                teacher.Office =
                    "A115";

                changed = true;
            }


            teacher =
                db.Teachers.FirstOrDefault(
                    t => t.Name == "Dr. James Bennett"
                );

            if (
                teacher != null &&
                string.IsNullOrWhiteSpace(
                    teacher.Office
                )
            )
            {
                teacher.Office =
                    "C214";

                changed = true;
            }


            if (changed)
            {
                db.SaveChanges();
            }
        }


        // Add missing teacher profile information

        private void AddDefaultProfiles()
        {
            bool changed = false;


            // SARA AL-HARBI profile

            var teacher =
                db.Teachers.FirstOrDefault(
                    t => t.Name == "Dr. Sara Al-Harbi"
                );


            if (teacher != null)
            {
                if (
                    string.IsNullOrWhiteSpace(
                        teacher.Title
                    )
                )
                {
                    teacher.Title =
                        "Associate Professor";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.About
                    )
                )
                {
                    teacher.About =
                        "Dr. Sara Al-Harbi specializes in artificial intelligence, " +
                        "machine learning, and intelligent software systems. " +
                        "Her academic work focuses on applying modern computing " +
                        "techniques to practical and educational challenges.";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.Education
                    )
                )
                {
                    teacher.Education =
                        "Ph.D. in Computer Science, University of Manchester|" +
                        "M.Sc. in Artificial Intelligence, King Saud University|" +
                        "B.Sc. in Computer Science, King Saud University";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.AcademicExperience
                    )
                )
                {
                    teacher.AcademicExperience =
                        "Associate Professor, Aurelia University (2022–Present)|" +
                        "Assistant Professor, Aurelia University (2018–2022)|" +
                        "Research Fellow in Artificial Intelligence (2016–2018)";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.ResearchInterests
                    )
                )
                {
                    teacher.ResearchInterests =
                        "Artificial Intelligence|" +
                        "Machine Learning|" +
                        "Intelligent Systems|" +
                        "Data Science";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.CoursesTaught
                    )
                )
                {
                    teacher.CoursesTaught =
                        "CS 350 — Artificial Intelligence|" +
                        "CS 320 — Machine Learning|" +
                        "CS 210 — Programming Fundamentals";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.Email
                    )
                )
                {
                    teacher.Email =
                        "sara.alharbi@aurelia.edu";

                    changed = true;
                }
            }


            // DANIEL FOSTER profile

            teacher =
                db.Teachers.FirstOrDefault(
                    t => t.Name == "Dr. Daniel Foster"
                );


            if (teacher != null)
            {
                if (
                    string.IsNullOrWhiteSpace(
                        teacher.Title
                    )
                )
                {
                    teacher.Title =
                        "Associate Professor";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.About
                    )
                )
                {
                    teacher.About =
                        "Dr. Daniel Foster teaches and researches modern biological " +
                        "sciences with an emphasis on biotechnology, cellular biology, " +
                        "and molecular processes. His work connects laboratory research " +
                        "with practical applications in life sciences.";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.Education
                    )
                )
                {
                    teacher.Education =
                        "Ph.D. in Molecular Biology, University of Edinburgh|" +
                        "M.Sc. in Biotechnology, King Abdulaziz University|" +
                        "B.Sc. in Biological Sciences, King Abdulaziz University";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.AcademicExperience
                    )
                )
                {
                    teacher.AcademicExperience =
                        "Associate Professor, Aurelia University (2021–Present)|" +
                        "Assistant Professor of Biology (2017–2021)|" +
                        "Molecular Biology Researcher (2014–2017)";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.ResearchInterests
                    )
                )
                {
                    teacher.ResearchInterests =
                        "Biotechnology|" +
                        "Molecular Biology|" +
                        "Cell Biology|" +
                        "Genetics";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.CoursesTaught
                    )
                )
                {
                    teacher.CoursesTaught =
                        "BIO 315 — Biotechnology|" +
                        "BIO 220 — Molecular Biology|" +
                        "BIO 110 — General Biology";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.Email
                    )
                )
                {
                    teacher.Email =
                        "daniel.foster@aurelia.edu";

                    changed = true;
                }
            }


            // EMMA COLLINS profile

            teacher =
                db.Teachers.FirstOrDefault(
                    t => t.Name == "Dr. Emma Collins"
                );


            if (teacher != null)
            {
                if (
                    string.IsNullOrWhiteSpace(
                        teacher.Title
                    )
                )
                {
                    teacher.Title =
                        "Assistant Professor";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.About
                    )
                )
                {
                    teacher.About =
                        "Dr. Emma Collins focuses on business strategy, " +
                        "organizational management, and entrepreneurship. " +
                        "Her teaching combines business theory with practical " +
                        "decision-making and modern management methods.";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.Education
                    )
                )
                {
                    teacher.Education =
                        "Ph.D. in Business Administration, University of Leeds|" +
                        "MBA, King Saud University|" +
                        "B.Sc. in Business Administration, Princess Nourah University";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.AcademicExperience
                    )
                )
                {
                    teacher.AcademicExperience =
                        "Assistant Professor, Aurelia University (2020–Present)|" +
                        "Business Strategy Lecturer (2017–2020)|" +
                        "Management Consultant (2014–2017)";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.ResearchInterests
                    )
                )
                {
                    teacher.ResearchInterests =
                        "Business Strategy|" +
                        "Entrepreneurship|" +
                        "Organizational Management|" +
                        "Leadership";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.CoursesTaught
                    )
                )
                {
                    teacher.CoursesTaught =
                        "BUS 310 — Strategic Management|" +
                        "BUS 220 — Organizational Behavior|" +
                        "BUS 101 — Introduction to Business";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.Email
                    )
                )
                {
                    teacher.Email =
                        "emma.collins@aurelia.edu";

                    changed = true;
                }
            }


            // FAISAL AL-DOSARI profile

            teacher =
                db.Teachers.FirstOrDefault(
                    t => t.Name == "Dr. Faisal Al-Dosari"
                );


            if (teacher != null)
            {
                if (
                    string.IsNullOrWhiteSpace(
                        teacher.Title
                    )
                )
                {
                    teacher.Title =
                        "Professor";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.About
                    )
                )
                {
                    teacher.About =
                        "Dr. Faisal Al-Dosari specializes in mechanical and engineering " +
                        "systems. His academic interests include system design, " +
                        "energy efficiency, and the development of reliable " +
                        "engineering solutions.";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.Education
                    )
                )
                {
                    teacher.Education =
                        "Ph.D. in Mechanical Engineering, University of Sheffield|" +
                        "M.Sc. in Engineering Systems, King Fahd University of Petroleum and Minerals|" +
                        "B.Sc. in Mechanical Engineering, King Fahd University of Petroleum and Minerals";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.AcademicExperience
                    )
                )
                {
                    teacher.AcademicExperience =
                        "Professor, Aurelia University (2023–Present)|" +
                        "Associate Professor of Engineering (2018–2023)|" +
                        "Senior Engineering Researcher (2014–2018)";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.ResearchInterests
                    )
                )
                {
                    teacher.ResearchInterests =
                        "Engineering Systems|" +
                        "Mechanical Design|" +
                        "Energy Efficiency|" +
                        "Automation";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.CoursesTaught
                    )
                )
                {
                    teacher.CoursesTaught =
                        "MEE 260 — Engineering Systems|" +
                        "MEE 240 — Mechanical Design|" +
                        "ENG 120 — Engineering Fundamentals";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.Email
                    )
                )
                {
                    teacher.Email =
                        "faisal.aldosari@aurelia.edu";

                    changed = true;
                }
            }


            // NORA AL-ANAZI profile

            teacher =
                db.Teachers.FirstOrDefault(
                    t => t.Name == "Dr. Nora Al-Anazi"
                );


            if (teacher != null)
            {
                if (
                    string.IsNullOrWhiteSpace(
                        teacher.Title
                    )
                )
                {
                    teacher.Title =
                        "Associate Professor";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.About
                    )
                )
                {
                    teacher.About =
                        "Dr. Nora Al-Anazi teaches applied and theoretical mathematics. " +
                        "Her work focuses on mathematical modeling, numerical methods, " +
                        "and the use of mathematics to solve scientific and " +
                        "engineering problems.";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.Education
                    )
                )
                {
                    teacher.Education =
                        "Ph.D. in Applied Mathematics, University of Birmingham|" +
                        "M.Sc. in Mathematics, King Saud University|" +
                        "B.Sc. in Mathematics, Princess Nourah University";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.AcademicExperience
                    )
                )
                {
                    teacher.AcademicExperience =
                        "Associate Professor, Aurelia University (2021–Present)|" +
                        "Assistant Professor of Mathematics (2017–2021)|" +
                        "Mathematics Lecturer (2014–2017)";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.ResearchInterests
                    )
                )
                {
                    teacher.ResearchInterests =
                        "Applied Mathematics|" +
                        "Mathematical Modeling|" +
                        "Numerical Analysis|" +
                        "Statistics";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.CoursesTaught
                    )
                )
                {
                    teacher.CoursesTaught =
                        "MATH 310 — Applied Mathematics|" +
                        "MATH 220 — Differential Equations|" +
                        "MATH 110 — Calculus";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.Email
                    )
                )
                {
                    teacher.Email =
                        "nora.alanazi@aurelia.edu";

                    changed = true;
                }
            }


            // JAMES BENNETT profile

            teacher =
                db.Teachers.FirstOrDefault(
                    t => t.Name == "Dr. James Bennett"
                );


            if (teacher != null)
            {
                if (
                    string.IsNullOrWhiteSpace(
                        teacher.Title
                    )
                )
                {
                    teacher.Title =
                        "Associate Professor";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.About
                    )
                )
                {
                    teacher.About =
                        "Dr. James Bennett specializes in software systems, " +
                        "databases, and cloud computing. His research focuses on " +
                        "scalable applications, reliable information systems, " +
                        "and modern software architecture.";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.Education
                    )
                )
                {
                    teacher.Education =
                        "Ph.D. in Computer Science, University of Toronto|" +
                        "M.Sc. in Computer Science, King Fahd University of Petroleum and Minerals|" +
                        "B.Sc. in Computer Science, King Saud University";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.AcademicExperience
                    )
                )
                {
                    teacher.AcademicExperience =
                        "Associate Professor, Aurelia University (2019–Present)|" +
                        "Assistant Professor of Computer Science (2016–2019)|" +
                        "Software Systems Researcher (2013–2016)";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.ResearchInterests
                    )
                )
                {
                    teacher.ResearchInterests =
                        "Distributed Systems|" +
                        "Cloud Computing|" +
                        "Database Systems|" +
                        "Software Architecture";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.CoursesTaught
                    )
                )
                {
                    teacher.CoursesTaught =
                        "CS 340 — Database Systems|" +
                        "CS 330 — Cloud Computing|" +
                        "CS 220 — Data Structures";

                    changed = true;
                }


                if (
                    string.IsNullOrWhiteSpace(
                        teacher.Email
                    )
                )
                {
                    teacher.Email =
                        "james.bennett@aurelia.edu";

                    changed = true;
                }
            }


            // =====================================================
            // SAVE PROFILE DATA
            // =====================================================

            if (changed)
            {
                db.SaveChanges();
            }
        }


        // Show teacher details

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest
                );
            }


            Teacher teacher =
                db.Teachers.Find(id);


            if (teacher == null)
            {
                return HttpNotFound();
            }


            return View(teacher);
        }


        // Add a new teacher

        [AdminOnly]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminOnly]
        public ActionResult Create(
            [Bind(Include =
                "TeacherId,Name,Subject,Office,Title,About,Education," +
                "AcademicExperience,ResearchInterests,CoursesTaught," +
                "Email,ImagePath")]
            Teacher teacher
        )
        {
            if (ModelState.IsValid)
            {
                db.Teachers.Add(
                    teacher
                );


                db.SaveChanges();


                return RedirectToAction(
                    "Index"
                );
            }


            return View(
                teacher
            );
        }


        // Edit teacher information

        [AdminOnly]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest
                );
            }


            Teacher teacher =
                db.Teachers.Find(id);


            if (teacher == null)
            {
                return HttpNotFound();
            }


            return View(teacher);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminOnly]
        public ActionResult Edit(
            [Bind(Include =
                "TeacherId,Name,Subject,Office,Title,About,Education," +
                "AcademicExperience,ResearchInterests,CoursesTaught," +
                "Email,ImagePath")]
            Teacher teacher
        )
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacher).State =
                    EntityState.Modified;


                db.SaveChanges();


                return RedirectToAction(
                    "Index"
                );
            }


            return View(
                teacher
            );
        }


        // Delete teacher record

        [AdminOnly]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest
                );
            }


            Teacher teacher =
                db.Teachers.Find(id);


            if (teacher == null)
            {
                return HttpNotFound();
            }


            return View(teacher);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AdminOnly]
        public ActionResult DeleteConfirmed(int id)
        {
            Teacher teacher =
                db.Teachers.Find(id);


            if (teacher == null)
            {
                return HttpNotFound();
            }


            db.Teachers.Remove(
                teacher
            );


            db.SaveChanges();


            return RedirectToAction(
                "Index"
            );
        }


        // Release database resources

        protected override void Dispose(
            bool disposing
        )
        {
            if (disposing)
            {
                db.Dispose();
            }


            base.Dispose(
                disposing
            );
        }
    }
}