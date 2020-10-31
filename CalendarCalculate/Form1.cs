using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace CalendarCalculate
{
    public partial class Form1 : Form
    {
        GregorianCalendar gc = new GregorianCalendar(GregorianCalendarTypes.Localized);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void year_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == '\r' || e.KeyChar == 13) //按下Enter鍵
                {
                    if (!string.IsNullOrEmpty((sender as TextBox).Text.Trim()))
                    {
                        int yearValue = Convert.ToInt32((sender as TextBox).Text.Trim());
                        if (!CheckYearRangePass(yearValue))
                        {
                            MessageBox.Show("年份,請輸入1~9999", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                            (sender as TextBox).Text = string.Empty;
                            (sender as TextBox).Focus();
                        }
                        else
                        {
                            weekth.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("年份不可為空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

        private void weekth_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(year.Text.Trim()))
                {
                    const int totalMonthCount = 12;     //總共有幾個月
                    int yearValue = -1;                 //輸入的年份
                    int weekthValue = -1;               //輸入的第幾週
                    int weeksInYear = -1;               //該年有多少週
                    bool yearIntParseResult = int.TryParse(year.Text.Trim(), out yearValue); //剖析輸入的年份是否為整數
                    if (e.KeyChar == '\r' || e.KeyChar == 13) //按下Enter鍵
                    {
                        if (!string.IsNullOrEmpty((sender as TextBox).Text.Trim()))
                        {
                            if (yearIntParseResult)
                            {
                                weeksInYear = GetWeeksInYear(yearValue); //取得輸入年份的總週數
                            }
                            if (sender is TextBox)
                            {
                                weekthValue = Convert.ToInt32((sender as TextBox).Text.Trim()); //輸入的第幾週
                            }

                            //利用呼叫方法取得開頭日期
                            calBeginDate.Text = GetWeekthToDateBegin(yearValue, weekthValue).ToString("yyyy-MM-dd");

                            //檢查年份的範圍
                            if (CheckYearRangePass(yearValue))
                            {
                                DateTime yearFirstDayDate = new DateTime(yearValue, 1, 1); //第一天的日期
                                DateTime yearLastDayDate = new DateTime(yearValue, 12, 31); //最後一天的日期
                                //檢查第幾週的範圍
                                if (CheckWeekthRangePass(weekthValue))
                                {
                                    //宣告string[54,7]
                                    DateTime[,] dateString = new DateTime[54, 7];
                                    //產生每一天的日期元素
                                    for (int m = 1; m <= totalMonthCount; )
                                    {
                                        int daysInMonth = DateTime.DaysInMonth(yearValue, m);
                                        for (int d = 1; d <= daysInMonth; )
                                        {
                                            //把產生的日期元素,插入陣列中
                                            for (int i = 0; i <= weeksInYear; )
                                            {
                                                DateTime insertDate = new DateTime(yearValue, m, d);
                                                int weekDay = (int)insertDate.DayOfWeek;
                                                DateTime saturday = dateString[i, 6];
                                                string noSetDateString = "0001-01-01";
                                                string saturdayString = (saturday.ToString("yyyy-MM-dd") != noSetDateString) ? saturday.ToString("yyyy-MM-dd") : string.Empty;
                                                for (int j = weekDay; j <= 6; j++)
                                                {
                                                    if (saturdayString != string.Empty)
                                                    {
                                                        dateString[i, j] = insertDate;
                                                    }
                                                    else
                                                    {
                                                        dateString[i, j] = insertDate;
                                                        if (d < daysInMonth)
                                                        {
                                                            d++;
                                                            insertDate = new DateTime(yearValue, m, d);
                                                        }
                                                        else if (d == daysInMonth)
                                                        {
                                                            if (m < totalMonthCount && m >= 1) //月份小於12
                                                            {
                                                                m++;
                                                                d = 1;
                                                                insertDate = new DateTime(yearValue, m, d);
                                                                daysInMonth = DateTime.DaysInMonth(yearValue, m);
                                                            }
                                                            else
                                                            {
                                                                if (weekthValue <= 0)
                                                                {
                                                                    MessageBox.Show("輸入的週數必須大於0", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                                                                    weekth.Text = string.Empty;
                                                                    calculatedDateInterval.Text = string.Empty;
                                                                    calBeginDate.Text = string.Empty;
                                                                }
                                                                else if (weekthValue <= weeksInYear && weekthValue > 0)
                                                                {
                                                                    //把第幾週換算成開頭日期的結果輸出到calculatedDate
                                                                    DateTime targetDateBegin = dateString[weekthValue - 1, 0];
                                                                    string targetDateBeginString = targetDateBegin.ToString("yyyy-MM-dd");
                                                                    DateTime targetDateEnd = dateString[weekthValue - 1, 6];
                                                                    string targetDateEndString = targetDateEnd.ToString("yyyy-MM-dd");
                                                                    if (weekthValue > 1 && weekthValue < weeksInYear && targetDateEnd != yearLastDayDate)
                                                                    {
                                                                        calculatedDateInterval.Text = targetDateBeginString + "(" + targetDateBegin.DayOfWeek + ")" +
                                                                            "～" + targetDateEndString + "(" + targetDateEnd.DayOfWeek + ")";
                                                                    }
                                                                    else if (weekthValue == 1)
                                                                    {
                                                                        targetDateBegin = yearFirstDayDate;
                                                                        targetDateBeginString = targetDateBegin.ToString("yyyy-MM-dd");
                                                                        calculatedDateInterval.Text = targetDateBeginString + "(" + targetDateBegin.DayOfWeek + ")" +
                                                                            "～" + targetDateEndString + "(" + targetDateEnd.DayOfWeek + ")";
                                                                    }
                                                                    else if (weekthValue == weeksInYear)
                                                                    {
                                                                        targetDateEnd = yearLastDayDate;
                                                                        targetDateEndString = targetDateEnd.ToString("yyyy-MM-dd");
                                                                        if (targetDateBegin == targetDateEnd)
                                                                        {
                                                                            calculatedDateInterval.Text = targetDateBeginString + "(" + targetDateBegin.DayOfWeek + ")";
                                                                        }
                                                                        else
                                                                        {
                                                                            calculatedDateInterval.Text = targetDateBeginString + "(" + targetDateBegin.DayOfWeek + ")" +
                                                                                "～" + targetDateEndString + "(" + targetDateEnd.DayOfWeek + ")";
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("您輸入的週數已超過範圍", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                                                                    calculatedDateInterval.Text = string.Empty;
                                                                    calBeginDate.Text = string.Empty;
                                                                }
                                                                //結束程序
                                                                return;
                                                            }
                                                        }

                                                        if (j == 6)
                                                        {
                                                            saturdayString = string.Empty;
                                                            i++;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("第幾週,請輸入1~53", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                                }
                            }
                            else
                            {
                                MessageBox.Show("年份,請輸入1~9999", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                            }
                        }
                        else
                        {
                            MessageBox.Show("第幾週不可為空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("年份不可為空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

        /// <summary>
        /// 檢查年份的範圍
        /// </summary>
        /// <param name="yearValue"></param>
        /// <returns></returns>
        public bool CheckYearRangePass(int yearValue)
        {
            if (yearValue >= 1 && yearValue <= 9999)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 檢查第幾週的範圍
        /// </summary>
        /// <param name="yearValue"></param>
        /// <returns></returns>
        public bool CheckWeekthRangePass(int weekthValue)
        {
            if (weekthValue > 1 || weekthValue < 53)
                return true;
            else
                return false;
        }

        //取得該年有多少週
        public int GetWeeksInYear(int yearValue)
        {
            DateTime end = new DateTime(yearValue, 12, 31);  //該年最後一天
            return gc.GetWeekOfYear(end, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);  //該年的週數
        }

        /// <summary>
        /// 取得第幾週的開頭日期
        /// </summary>
        /// <param name="yearValue"></param>
        /// <param name="weekthValue"></param>
        /// <returns></returns>
        public DateTime GetWeekthToDateBegin(int yearValue, int weekthValue)
        {
            DateTime calculatedDateBegin = new DateTime(yearValue, 1, 1);
            try
            {
                const int totalMonthCount = 12;             //總共有幾個月
                int weeksInYear = -1;                       //該年有多少週(總週數)
                weeksInYear = GetWeeksInYear(yearValue);    //取得輸入年份的總週數
                //檢查年份的範圍
                if (CheckYearRangePass(yearValue))
                {
                    DateTime yearFirstDayDate = new DateTime(yearValue, 1, 1);  //第一天的日期
                    DateTime yearLastDayDate = new DateTime(yearValue, 12, 31); //最後一天的日期
                    //檢查第幾週的範圍
                    if (CheckWeekthRangePass(weekthValue))
                    {
                        //宣告string[54,7]
                        DateTime[,] dateString = new DateTime[54, 7];
                        //產生每一天的日期元素
                        for (int m = 1; m <= totalMonthCount; )
                        {
                            int daysInMonth = DateTime.DaysInMonth(yearValue, m); //指定年月的天數
                            for (int d = 1; d <= daysInMonth; )
                            {
                                //把產生的日期元素,插入陣列中
                                for (int i = 0; i <= weeksInYear; ) //陣列元素,列索引值的範圍
                                {
                                    DateTime insertDate = new DateTime(yearValue, m, d);
                                    int weekDay = (int)insertDate.DayOfWeek;    //插入日期是星期幾
                                    DateTime saturday = dateString[i, 6];       //星期六
                                    string noSetDateString = "0001-01-01";
                                    string saturdayString = (saturday.ToString("yyyy-MM-dd") != noSetDateString) ? saturday.ToString("yyyy-MM-dd") : string.Empty;
                                    for (int j = weekDay; j <= 6; j++) //陣列元素,行索引值的範圍
                                    {
                                        //若星期六格子元素的字串不為空字串
                                        if (saturdayString != string.Empty)
                                        {
                                            dateString[i, j] = insertDate; //插入日期
                                        }
                                        else
                                        {
                                            dateString[i, j] = insertDate;
                                            if (d < daysInMonth) //目前日數小於該月份總日數
                                            {
                                                d++; //目前日數+1
                                                insertDate = new DateTime(yearValue, m, d); //設定插入為新日期
                                            }
                                            else if (d == daysInMonth) //目前日數等於該月份總日數
                                            {
                                                if (m < totalMonthCount && m >= 1) //月份小於12
                                                {
                                                    m++;    //月份+1
                                                    d = 1;  //目前日數設為1
                                                    insertDate = new DateTime(yearValue, m, d);         //設定插入為新日期
                                                    daysInMonth = DateTime.DaysInMonth(yearValue, m);   //更新總日數
                                                }
                                                else
                                                {
                                                    if (weekthValue <= 0) //第幾週小於0
                                                    {
                                                        MessageBox.Show("輸入的週數必須大於0", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                                                    }
                                                    else if (weekthValue <= weeksInYear && weekthValue > 0) //第幾週<=總週數
                                                    {
                                                        //把第幾週換算成開頭日期的結果輸出到calculatedDate
                                                        DateTime targetDateBegin = dateString[weekthValue - 1, 0];              //開頭日期
                                                        string targetDateBeginString = targetDateBegin.ToString("yyyy-MM-dd");  //開頭日期字串
                                                        DateTime targetDateEnd = dateString[weekthValue - 1, 6];                //結尾日期
                                                        string targetDateEndString = targetDateEnd.ToString("yyyy-MM-dd");      //結尾日期字串
                                                        if (weekthValue > 1 && weekthValue < weeksInYear && targetDateEnd != yearLastDayDate)
                                                        {
                                                            calculatedDateBegin = targetDateBegin;
                                                        }
                                                        else if (weekthValue == 1)
                                                        {
                                                            targetDateBegin = yearFirstDayDate;
                                                            targetDateBeginString = targetDateBegin.ToString("yyyy-MM-dd");
                                                            calculatedDateBegin = targetDateBegin;
                                                        }
                                                        else if (weekthValue == weeksInYear)
                                                        {
                                                            targetDateEnd = yearLastDayDate;
                                                            targetDateEndString = targetDateEnd.ToString("yyyy-MM-dd");
                                                            if (targetDateBegin == targetDateEnd)
                                                            {
                                                                calculatedDateBegin = targetDateEnd;
                                                            }
                                                            else
                                                            {
                                                                calculatedDateBegin = targetDateBegin;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("您輸入的週數已超過範圍", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                                                    }
                                                    //結束程序
                                                    return calculatedDateBegin;
                                                }
                                            }

                                            if (j == 6) //若週數索引值跑到6
                                            {
                                                saturdayString = string.Empty; //星期六字串設為空
                                                i++; //列索引+1
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("第幾週,請輸入1~53", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    }
                }
                else
                {
                    MessageBox.Show("年份,請輸入1~9999", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            return calculatedDateBegin;
        }
    }
}
