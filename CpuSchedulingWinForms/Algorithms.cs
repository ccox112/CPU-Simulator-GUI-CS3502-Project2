﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpuSchedulingWinForms
{
    public static class Algorithms
    {
        public static void fcfsAlgorithm(string userInput)
        {
            var rand=new Random();
            int np = Convert.ToInt16(userInput);
            int npX2 = np * 2;

            double[] bp = new double[np];
            double[] wtp = new double[np];
            string[] output1 = new string[npX2];
            double twt = 0.0, awt;
            int num;

            DialogResult result = MessageBox.Show("First Come First Serve Scheduling ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (num = 0; num <= np - 1; num++)
                {
                    //MessageBox.Show("Enter Burst time for P" + (num + 1) + ":", "Burst time for Process", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    //Console.WriteLine("\nEnter Burst time for P" + (num + 1) + ":");

                    string input = Microsoft.VisualBasic.Interaction.InputBox("Enter Burst time: ", "Burst time for P" + (num + 1), "",  -1, -1);

                    bp[num] = Convert.ToInt64(input);
                    //bp[num] = rand.Next(3, 20);

                    //var input = Console.ReadLine();
                    //bp[num] = Convert.ToInt32(input);
                }

                for (num = 0; num <= np - 1; num++)
                {
                    if (num == 0)
                    {
                        wtp[num] = 0;
                    }
                    else
                    {
                        wtp[num] = wtp[num - 1] + bp[num - 1];
                        MessageBox.Show("Waiting time for P" + (num + 1) + " = " + wtp[num], "Job Queue", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }
                for (num = 0; num <= np - 1; num++)
                {
                    twt = twt + wtp[num];
                }
                awt = twt / np;
                MessageBox.Show("Average waiting time for " + np + " processes" + " = " + awt + " sec(s)", "Average Awaiting Time", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else if (result == DialogResult.No)
            {
                //this.Hide();
                //Form1 frm = new Form1();
                //frm.ShowDialog();
            }
        }

        public static void sjfAlgorithm(string userInput)
        {
            var rand = new Random();
            int np = Convert.ToInt16(userInput);

            double[] bp = new double[np];
            double[] wtp = new double[np];
            double[] p = new double[np];
            double twt = 0.0, awt;
            int x, num;
            double temp = 0.0;
            bool found = false;

            DialogResult result = MessageBox.Show("Shortest Job First Scheduling", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (num = 0; num <= np - 1; num++)
                {
                    string input = Microsoft.VisualBasic.Interaction.InputBox("Enter burst time: ","Burst time for P" + (num + 1), "", -1, -1);

                    bp[num] = Convert.ToInt64(input);
                    //bp[num] = rand.Next(3, 20);
                }
                for (num = 0; num <= np - 1; num++)
                {
                    p[num] = bp[num];
                }
                for (x = 0; x <= np - 2; x++)
                {
                    for (num = 0; num <= np - 2; num++)
                    {
                        if (p[num] > p[num + 1])
                        {
                            temp = p[num];
                            p[num] = p[num + 1];
                            p[num + 1] = temp;
                        }
                    }
                }
                for (num = 0; num <= np - 1; num++)
                {
                    if (num == 0)
                    {
                        for (x = 0; x <= np - 1; x++)
                        {
                            if (p[num] == bp[x] && found == false)
                            {
                                wtp[num] = 0;
                                MessageBox.Show("Waiting time for P" + (x + 1) + " = " + wtp[num], "Waiting time:", MessageBoxButtons.OK, MessageBoxIcon.None);
                                //Console.WriteLine("\nWaiting time for P" + (x + 1) + " = " + wtp[num]);
                                bp[x] = 0;
                                found = true;
                            }
                        }
                        found = false;
                    }
                    else
                    {
                        for (x = 0; x <= np - 1; x++)
                        {
                            if (p[num] == bp[x] && found == false)
                            {
                                wtp[num] = wtp[num - 1] + p[num - 1];
                                MessageBox.Show("Waiting time for P" + (x + 1) + " = " + wtp[num], "Waiting time", MessageBoxButtons.OK, MessageBoxIcon.None);
                                //Console.WriteLine("\nWaiting time for P" + (x + 1) + " = " + wtp[num]);
                                bp[x] = 0;
                                found = true;
                            }
                        }
                        found = false;
                    }
                }
                for (num = 0; num <= np - 1; num++)
                {
                    twt = twt + wtp[num];
                }
                MessageBox.Show("Average waiting time for " + np + " processes" + " = " + (awt = twt / np) + " sec(s)", "Average waiting time", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void priorityAlgorithm(string userInput)
        {
            var rand = new Random();
            int np = Convert.ToInt16(userInput);

            DialogResult result = MessageBox.Show("Priority Scheduling ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                double[] bp = new double[np];
                double[] wtp = new double[np + 1];
                int[] p = new int[np];
                int[] sp = new int[np];
                int x, num;
                double twt = 0.0;
                double awt;
                int temp = 0;
                bool found = false;
                for (num = 0; num <= np - 1; num++)
                {
                    string input = Microsoft.VisualBasic.Interaction.InputBox("Enter burst time: ","Burst time for P" + (num + 1),"",-1, -1);

                    bp[num] = Convert.ToInt64(input);
                    //bp[num] = rand.Next(3, 20);
                }
                for (num = 0; num <= np - 1; num++)
                {
                    string input2 =
                        Microsoft.VisualBasic.Interaction.InputBox("Enter priority: ",
                                                           "Priority for P" + (num + 1),
                                                           "",
                                                           -1, -1);

                    p[num] = Convert.ToInt16(input2);
                }
                for (num = 0; num <= np - 1; num++)
                {
                    sp[num] = p[num];
                }
                for (x = 0; x <= np - 2; x++)
                {
                    for (num = 0; num <= np - 2; num++)
                    {
                        if (sp[num] > sp[num + 1])
                        {
                            temp = sp[num];
                            sp[num] = sp[num + 1];
                            sp[num + 1] = temp;
                        }
                    }
                }
                for (num = 0; num <= np - 1; num++)
                {
                    if (num == 0)
                    {
                        for (x = 0; x <= np - 1; x++)
                        {
                            if (sp[num] == p[x] && found == false)
                            {
                                wtp[num] = 0;
                                MessageBox.Show("Waiting time for P" + (x + 1) + " = " + wtp[num], "Waiting time", MessageBoxButtons.OK);
                                //Console.WriteLine("\nWaiting time for P" + (x + 1) + " = " + wtp[num]);
                                temp = x;
                                p[x] = 0;
                                found = true;
                            }
                        }
                        found = false;
                    }
                    else
                    {
                        for (x = 0; x <= np - 1; x++)
                        {
                            if (sp[num] == p[x] && found == false)
                            {
                                wtp[num] = wtp[num - 1] + bp[temp];
                                MessageBox.Show("Waiting time for P" + (x + 1) + " = " + wtp[num], "Waiting time", MessageBoxButtons.OK);
                                //Console.WriteLine("\nWaiting time for P" + (x + 1) + " = " + wtp[num]);
                                temp = x;
                                p[x] = 0;
                                found = true;
                            }
                        }
                        found = false;
                    }
                }
                for (num = 0; num <= np - 1; num++)
                {
                    twt = twt + wtp[num];
                }
                MessageBox.Show("Average waiting time for " + np + " processes" + " = " + (awt = twt / np) + " sec(s)", "Average waiting time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Console.WriteLine("\n\nAverage waiting time: " + (awt = twt / np));
                //Console.ReadLine();
            }
            else
            {
                //this.Hide();
            }
        }

        public static void roundRobinAlgorithm(string userInput)
        {
            var rand = new Random();
            int np = Convert.ToInt16(userInput);
            int i, counter = 0;
            double total = 0.0;
            double timeQuantum;
            double waitTime = 0, turnaroundTime = 0;
            double averageWaitTime, averageTurnaroundTime;
            double[] arrivalTime = new double[np];
            double[] burstTime = new double[np];
            double[] temp = new double[np];
            int x = np;

            DialogResult result = MessageBox.Show("Round Robin Scheduling", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (i = 0; i < np; i++)
                {
                    string arrivalInput =  Microsoft.VisualBasic.Interaction.InputBox("Enter arrival time: ","Arrival time for P" + (i + 1),"", -1, -1);

                    arrivalTime[i] = Convert.ToInt64(arrivalInput);
                    //arrivalTime[i] = rand.Next(0, 10);

                    string burstInput = Microsoft.VisualBasic.Interaction.InputBox("Enter burst time: ", "Burst time for P" + (i + 1), "",  -1, -1);

                    burstTime[i] = Convert.ToInt64(burstInput);
                    //burstTime[i] = rand.Next(3, 20);

                    temp[i] = burstTime[i];
                }
                string timeQuantumInput =
                            Microsoft.VisualBasic.Interaction.InputBox("Enter time quantum: ", "Time Quantum",
                                                               "",
                                                               -1, -1);

                timeQuantum = Convert.ToInt64(timeQuantumInput);
                Helper.QuantumTime = timeQuantumInput;

                for (total = 0, i = 0; x != 0;)
                {
                    if (temp[i] <= timeQuantum && temp[i] > 0)
                    {
                        total = total + temp[i];
                        temp[i] = 0;
                        counter = 1;
                    }
                    else if (temp[i] > 0)
                    {
                        temp[i] = temp[i] - timeQuantum;
                        total = total + timeQuantum;
                    }
                    if (temp[i] == 0 && counter == 1)
                    {
                        x--;
                        //printf("nProcess[%d]tt%dtt %dttt %d", i + 1, burst_time[i], total - arrival_time[i], total - arrival_time[i] - burst_time[i]);
                        MessageBox.Show("Turnaround time for Process " + (i + 1) + " : " + (total - arrivalTime[i]), "Turnaround time for Process " + (i + 1), MessageBoxButtons.OK);
                        MessageBox.Show("Wait time for Process " + (i + 1) + " : " + (total - arrivalTime[i] - burstTime[i]), "Wait time for Process " + (i + 1), MessageBoxButtons.OK);
                        turnaroundTime = (turnaroundTime + total - arrivalTime[i]);
                        waitTime = (waitTime + total - arrivalTime[i] - burstTime[i]);
                        counter = 0;
                    }
                    if (i == np - 1)
                    {
                        i = 0;
                    }
                    else if (arrivalTime[i + 1] <= total)
                    {
                        i++;
                    }
                    else
                    {
                        i = 0;
                    }
                }
                averageWaitTime = Convert.ToInt64(waitTime * 1.0 / np);
                averageTurnaroundTime = Convert.ToInt64(turnaroundTime * 1.0 / np);
                MessageBox.Show("Average wait time for " + np + " processes: " + averageWaitTime + " sec(s)", "", MessageBoxButtons.OK);
                MessageBox.Show("Average turnaround time for " + np + " processes: " + averageTurnaroundTime + " sec(s)", "", MessageBoxButtons.OK);
                MessageBox.Show("Throughput of scheduler: " + (np / total) + " processes per second ", "", MessageBoxButtons.OK);
            }
        }
        public static void srtfAlgorithm(string userInput)
        {
            var rand = new Random();
            int np = Convert.ToInt16(userInput);
            Process[] processList = new Process[np];
            double[] arrivalTime = new double[np];
            double[] burstTime = new double[np];
            double totalTime = 0;
            double averageWaitTime = 0, averageTurnaroundTime = 0;
            int remainingProcesses = np;

            DialogResult result = MessageBox.Show("Choose Shortest Remaining Time First Algorithm ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < np; i++)
                {
                    
                    string arrivalInput = Microsoft.VisualBasic.Interaction.InputBox("Enter arrival time: ", "Arrival time for process " + (i + 1), "", -1, -1);
                    arrivalTime[i] = Convert.ToInt64(arrivalInput);
                    //arrivalTime[i] = rand.Next(0, 10);

                    string burstInput = Microsoft.VisualBasic.Interaction.InputBox("Enter burst time: ", "Burst time for process " + (i + 1), "", -1, -1);
                    burstTime[i] = Convert.ToInt64(burstInput);
                    //burstTime[i] = rand.Next(3, 20);

                    processList[i] = new Process(arrivalTime[i], burstTime[i], i + 1);

                }
                while (remainingProcesses != 0) {
                    int shortest = 10000;
                    for (int j = 0; j < processList.Length; j++)
                    {
                        if (processList[j].getArrivalTime() <= totalTime && processList[j].getRemainingTime() > 0 && (shortest == 10000 || processList[j].getRemainingTime() < processList[shortest].getRemainingTime())) {
                            shortest = j;
                        }
                    }
                    if (shortest != 10000)
                    {
                        processList[shortest].decreaseRemainingTime();
                        totalTime++;
                        if (processList[shortest].getRemainingTime() == 0)
                        {
                            processList[shortest].processComplete(totalTime);
                            remainingProcesses--;
                        }
                    }
                    else
                    {
                        totalTime++;
                    }
                }
                for (int j = 0; j < processList.Length; j++)
                {
                    if (processList[j].getWaitingTime() < 0)
                    {
                        processList[j].setArrivalTime(0);
                    }
                    MessageBox.Show("Waiting time for Process " + (j + 1) + " : " + processList[j].getWaitingTime(), "Waiting time for Process " + (j + 1), MessageBoxButtons.OK);
                    MessageBox.Show("Turnaround time for Process " + (j + 1) + " : " + processList[j].getTurnaroundTime(), "Turnaround time for Process " + (j + 1), MessageBoxButtons.OK);
                    averageWaitTime += processList[j].getWaitingTime();
                    averageTurnaroundTime += processList[j].getTurnaroundTime();
                }
                averageWaitTime = Convert.ToInt64(averageWaitTime * 1.0 / np);
                averageTurnaroundTime = Convert.ToInt64(averageTurnaroundTime * 1.0 / np);

                MessageBox.Show("Average wait time for " + np + " processes: " + averageWaitTime + " sec(s)", "", MessageBoxButtons.OK);
                MessageBox.Show("Average turnaround time for " + np + " processes: " + averageTurnaroundTime + " sec(s)", "", MessageBoxButtons.OK);
                MessageBox.Show("Throughput of scheduler: " + (np / totalTime) + " processes per second ", "", MessageBoxButtons.OK);
            }
        }
        public static void hrrnAlgorithm(string userInput)
        {
            var rand = new Random();
            int np = Convert.ToInt16(userInput);
            Process[] processList = new Process[np];
            double[] arrivalTime = new double[np];
            double[] burstTime = new double[np];
            double totalTime = 0, averageWaitTime = 0, averageTurnaroundTime = 0;
            int remainingProcesses = np;
            DialogResult result = MessageBox.Show("Choose Highest Response Ratio Next Algorithm ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                for (int i = 0; i < np; i++) {
                    string arrivalInput = Microsoft.VisualBasic.Interaction.InputBox("Enter arrival time: ", "Arrival time for process " + (i + 1), "", -1, -1);
                    string burstInput = Microsoft.VisualBasic.Interaction.InputBox("Enter burst time: ", "Burst time for process " + (i + 1), "", -1, -1);

                    arrivalTime[i] = Convert.ToInt64(arrivalInput);
                    //arrivalTime[i] = rand.Next(0, 10);
                    burstTime[i] = Convert.ToInt64(burstInput);
                    //burstTime[i] = rand.Next(3, 20);
                    processList[i] = new Process(arrivalTime[i], burstTime[i], i + 1);
                }
                while (remainingProcesses != 0)
                {
                    int highestResponseNumber = 0;
                    double highestResponse = 0;
                    for (int j = 0; j < processList.Length; j++)
                    {
                        if (processList[j].getArrivalTime() < totalTime && processList[j].getRemainingTime() > 0)
                        {
                            double responseRatio = ((processList[j].getWaitingTime() + processList[j].getBurstTime()) / processList[j].getBurstTime());
                            if (responseRatio > highestResponse)
                            {
                                highestResponse = responseRatio;
                                highestResponseNumber = j;
                            }

                        }
                    }

                            totalTime += processList[highestResponseNumber].getRemainingTime();
                            processList[highestResponseNumber].setRemainingTime(0);
                            processList[highestResponseNumber].processComplete(totalTime);
                            remainingProcesses--;
                       
 
                    }
                    for (int j = 0; j < processList.Length; j++)
                    {
                    if (processList[j].getWaitingTime() < 0)
                    {
                        processList[j].setArrivalTime(0);
                    }
                        MessageBox.Show("Waiting time for Process " + (j + 1) + " : " + processList[j].getWaitingTime(), "Waiting time for Process " + (j + 1), MessageBoxButtons.OK);
                        MessageBox.Show("Turnaround time for Process " + (j + 1) + " : " + processList[j].getTurnaroundTime(), "Turnaround time for Process " + (j + 1), MessageBoxButtons.OK);
                        averageWaitTime += processList[j].getWaitingTime();
                        averageTurnaroundTime += processList[j].getTurnaroundTime();
                    }
                    averageWaitTime = Convert.ToInt64(averageWaitTime * 1.0 / np);
                    averageTurnaroundTime = Convert.ToInt64(averageTurnaroundTime * 1.0 / np);

                    MessageBox.Show("Average wait time for " + np + " processes: " + averageWaitTime + " sec(s)", "", MessageBoxButtons.OK);
                    MessageBox.Show("Average turnaround time for " + np + " processes: " + averageTurnaroundTime + " sec(s)", "", MessageBoxButtons.OK);
                    MessageBox.Show("Throughput of scheduler: " + (np/totalTime) + " processes per second ", "", MessageBoxButtons.OK);
            }

            }
        }
        public class Process
        {
            int processID; public double arrivalTime, burstTime, remainingTime, waitingTime, turnaroundTime, completionTime;
            public Process(double arrivalTime, double burstTime, int process)
            {
                this.processID = process;
                this.arrivalTime = arrivalTime;
                this.burstTime = burstTime;
                this.remainingTime = burstTime;
            }
            public double getArrivalTime() { return this.arrivalTime; }
            public void setArrivalTime(int change) { this.arrivalTime = change; }
            public double getRemainingTime() { return this.remainingTime; }
            public double getCompletionTime() { return this.completionTime; }
            public double getTurnaroundTime() { return this.turnaroundTime; }
            public double getWaitingTime() { return this.waitingTime; }
            public double getBurstTime() { return this.burstTime; }
            public void decreaseRemainingTime() { this.remainingTime--; }
            public void setRemainingTime(double completedTime) { this.remainingTime = completedTime; }
            public void processComplete(double totalTime) {
                this.completionTime = totalTime;
                this.turnaroundTime = (totalTime - arrivalTime);
                this.waitingTime = (turnaroundTime - burstTime);
            }
        }
    } 

