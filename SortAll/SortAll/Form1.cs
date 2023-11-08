using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace SortAll
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Enabled = false;
                numericUpDown1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = true;
                numericUpDown1.Enabled = false;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        Stopwatch stopwatch;

        private void button2_Click(object sender, EventArgs e)
        {

            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWorkBubbleSort);

            stopwatch = new Stopwatch();

            stopwatch.Start();

            timer1.Start();

            int[] numbers = SortS();

            var numbers_c = numbers.ToArray();

            this.bw.RunWorkerAsync(numbers_c);

            this.bw.DoWork -= new System.ComponentModel.DoWorkEventHandler(this.bw_DoWorkBubbleSort);

            Res(numbers);
        }

        private int[] SortS()
        {
            string inputText = textBox1.Text;

            string[] numberStrings = inputText.Split(' ');

            int[] numbers = new int[numberStrings.Length];

            for (int i = 0; i < numberStrings.Length; i++)
            {
                numbers[i] = int.Parse(numberStrings[i]);
            }

            return numbers;
        }

        private void Res(int[] numbers)
        {
            string sortedText = string.Join(" ", numbers);

            textBox2.Text = sortedText;

        }

        private void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i < n; i++)
                {
                    if (arr[i - 1] > arr[i])
                    {
                    
                        int temp = arr[i - 1];
                        arr[i - 1] = arr[i];
                        arr[i] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWorkSelectionSort);

            stopwatch = new Stopwatch();

            stopwatch.Start();

            timer1.Start();

            int[] numbers = SortS();

            var numbers_c = numbers.ToArray();

            this.bw.RunWorkerAsync(numbers_c);

            this.bw.DoWork -= new System.ComponentModel.DoWorkEventHandler(this.bw_DoWorkSelectionSort);

            Res(numbers);
        }

        private void SelectionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    
                    int temp = arr[i];
                    arr[i] = arr[minIndex];
                    arr[minIndex] = temp;
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWorkInsertionSort);

            stopwatch = new Stopwatch();

            stopwatch.Start();

            timer1.Start();

            int[] numbers = SortS();

            var numbers_c = numbers.ToArray();

            this.bw.RunWorkerAsync(numbers_c);

            this.bw.DoWork -= new System.ComponentModel.DoWorkEventHandler(this.bw_DoWorkInsertionSort);

            Res(numbers);
        }

        private void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                int current = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > current)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = current;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWorkMergeSort);

            stopwatch = new Stopwatch();

            stopwatch.Start();

            timer1.Start();

            int[] numbers = SortS();

            var numbers_c = numbers.ToArray();

            this.bw.RunWorkerAsync(numbers_c);

            this.bw.DoWork -= new System.ComponentModel.DoWorkEventHandler(this.bw_DoWorkMergeSort);

            Res(numbers);
        }

        private void MergeSort(int[] arr)
        {
            int n = arr.Length;
            if (n <= 1)
                return;

            int mid = n / 2;
            int[] left = new int[mid];
            int[] right = new int[n - mid];

            for (int i = 0; i < mid; i++)
                left[i] = arr[i];

            for (int i = mid; i < n; i++)
                right[i - mid] = arr[i];

            MergeSort(left);
            MergeSort(right);

            Merge(arr, left, right);
        }

        private void Merge(int[] arr, int[] left, int[] right)
        {
            int nL = left.Length;
            int nR = right.Length;
            int i = 0, j = 0, k = 0;

            while (i < nL && j < nR)
            {
                if (left[i] <= right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }
                k++;
            }

            while (i < nL)
            {
                arr[k] = left[i];
                i++;
                k++;
            }

            while (j < nR)
            {
                arr[k] = right[j];
                j++;
                k++;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWorkQuickSort);

            stopwatch = new Stopwatch();

            stopwatch.Start();

            timer1.Start();

            int[] numbers = SortS();

            var numbers_c = numbers.ToArray();

            this.bw.RunWorkerAsync(numbers_c);

            this.bw.DoWork -= new System.ComponentModel.DoWorkEventHandler(this.bw_DoWorkQuickSort);

            Res(numbers);
        }

        private void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pivot = Partition(arr, low, high);

                QuickSort(arr, low, pivot - 1);
                QuickSort(arr, pivot + 1, high);
            }
        }

        private int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return i + 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int numberOfNumbers = (int)numericUpDown1.Value;

            if (numberOfNumbers > 2000000)
            {
                MessageBox.Show("Max 2 mln");
                return;
            }

            Random random = new Random();

            string numbersText = string.Empty;
            for (int i = 0; i < numberOfNumbers; i++)
            {
                int randomNumber = random.Next();
                numbersText += randomNumber.ToString() + " ";
            }

            textBox1.Text = numbersText.Trim();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void bw_DoWorkBubbleSort(object sender, DoWorkEventArgs e)
        {
            int[] tab = e.Argument as int[];

            BubbleSort(tab);
            timer1.Stop();
        }

        private void bw_DoWorkSelectionSort(object sender, DoWorkEventArgs e)
        {
            int[] tab = e.Argument as int[];

            SelectionSort(tab);
            timer1.Stop();
        }

        private void bw_DoWorkInsertionSort(object sender, DoWorkEventArgs e)
        {
            int[] tab = e.Argument as int[];

            InsertionSort(tab);
            timer1.Stop();
        }

        private void bw_DoWorkMergeSort(object sender, DoWorkEventArgs e)
        {
            int[] tab = e.Argument as int[];

            MergeSort(tab);
            timer1.Stop();
        }

        private void bw_DoWorkQuickSort(object sender, DoWorkEventArgs e)
        {
            int[] tab = e.Argument as int[];

            QuickSort(tab, 0, tab.Length - 1);
            timer1.Stop();
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            stopwatch.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = stopwatch.Elapsed.ToString();
        }
    }
}
