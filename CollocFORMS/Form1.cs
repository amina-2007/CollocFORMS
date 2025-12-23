using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollocFORMS
{
    public partial class Form1 : Form
    {
        private Schedule schedule;  

        public Form1()
        {
            InitializeComponent();
            schedule = new Schedule("ПРИМАТ");
             
            schedule.Add(new Lesson("Матанализ", 1, 0, WeekDays.Tuesday, "21"));
            schedule.Add(new Lesson("Алгебра", 2, 2, WeekDays.Tuesday, "21"));
             
            UpdateDataGrid();
            UpdateLabels();
        }
        private void UpdateDataGrid()
        { 
            dataGridRasp.Rows.Clear(); 
           
             
            foreach (var lesson in schedule.listLessons)
            {
                dataGridRasp.Rows.Add(
                    lesson.label,
                    lesson.number,
                    lesson.weekDay.ToString(),
                    lesson.weekNumber,
                    lesson.groupNumber
                ); 
            }
        }
        private void UpdateLabels()
        {
            label1.Text = $"Факультет: {schedule.nameDepartment}";
            label2.Text = $"Всего пар: {schedule.listLessons.Count}";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        { 
            Lesson newLesson = new Lesson();
            schedule.Add(newLesson);
             
            UpdateDataGrid();
             
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            Lesson newLesson = new Lesson();
            schedule.Add(newLesson);

            dataGridRasp.Rows.Add(
                newLesson.label,
                newLesson.number,
                newLesson.weekDay.ToString(),
                newLesson.weekNumber,
                newLesson.groupNumber
            );

            label2.Text = $"Всего пар: {schedule.listLessons.Count}";
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridRasp.SelectedRows.Count > 0)
            {
                int index = dataGridRasp.SelectedRows[0].Index;
                if (index < schedule.listLessons.Count)
                {
                    schedule.listLessons.RemoveAt(index);
                    dataGridRasp.Rows.RemoveAt(index);
                    label2.Text = $"Всего пар: {schedule.listLessons.Count}";
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            schedule.listLessons = schedule.listLessons
      .OrderBy(lesson => lesson.weekDay)
      .ThenBy(lesson => lesson.number)
      .ToList();

            UpdateDataGrid();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            schedule.listLessons = schedule.listLessons
       .OrderBy(lesson => lesson.groupNumber)
       .ThenBy(lesson => lesson.number)
       .ToList();

            UpdateDataGrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            schedule.listLessons = schedule.listLessons
      .OrderBy(lesson => lesson.weekNumber)
      .ThenBy(lesson => lesson.weekDay)
      .ThenBy(lesson => lesson.number)
      .ToList();

            UpdateDataGrid();
        }
    }
}
