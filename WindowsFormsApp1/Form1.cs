using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using AForge;
using AForge.Imaging;
using AForge.Imaging.ColorReduction;
using AForge.Imaging.Filters;
using ColorService;
using Point = AForge.Point;
using System.IO;
using System.Threading;

//try/catch blocks to log true false, will want to log error messages on screen.
//Optimize code, make it iterate through process faster
//multi-thread on 
//will break down color code into oop object using mutli thread down the line.

//Log each function start time and end time
//*use tick count now at start, then tic count at end - tick.

//start debugging and logging errors.
//need to debug rotation
//business rule, need to rotate 360 degrees and measure
//rotate one blob and take measurements, display on info.

//Convert all items to functions and rotate 360



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Bitmap _BitmapOriginal;
        private List<PictureBox> pictureBoxes = new List<PictureBox>();
        private int _Degrees = 0;
        private Color[] _ColorTable;
        private Bitmap _BitmapReduce;
        private readonly IColorOperator _ColorOperator = new ColorOperator();
        private int _ColornNumber;
        private Bitmap _BitmapColorFiltered;
        private Color[] _DictinctColorList;
        private Bitmap _BitmapMagicWand;
        public Bitmap _BitmapRotate;
        private Bitmap _BitmapZoom ;
        private Bitmap _BitmapMeasure ;
        private long tickBegin;
        private long tickEnd;
        private string stringPoints;
        private string line = "";
        private int counter = 0;
        private Bitmap nextthisButtonInputBitmap;
        //Thread thread;isMagicWandNull
        private bool isMagicWandNull;


        public Form1()
        {
            InitializeComponent();
            stringPoints = "";
            pictureBoxes.Add(pictureBox1);
            pictureBoxes.Add(pictureBox2);
            pictureBoxes.Add(pictureBox3);
            pictureBoxes.Add(pictureBox4);
        }
       
        private void LoadImage_Click(object sender, EventArgs e)
        {
            ClearStuff();
            // open file dialog 
            OpenFileDialog open = new OpenFileDialog();
            // image filters
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            try
            {
                if (open.ShowDialog() == DialogResult.OK)
                {
                    // display image in picture box
                    // pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = new Bitmap(open.FileName);
                    // image file path
                    _BitmapOriginal = (Bitmap)pictureBox1.Image;


                }
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
           
        }
        private void PictureBoxVisibility(bool value)
        {
            foreach (var picturebox in pictureBoxes)
            {
                picturebox.Visible = value;
            }
        }
        private void debugCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            if (debugCheckBox.Checked)
                PictureBoxVisibility(true);
            else
                PictureBoxVisibility(false);
        }

        #region Automated Functions
        private void automateBtn_Click(object sender, EventArgs e)
        {
            tickBegin = DateTime.Now.Ticks;
            ClearStuff();
            // open file dialog 
            OpenFileDialog open = new OpenFileDialog();
            // image filters
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                tickBegin = DateTime.Now.Ticks;
                // display image in picture box
                // pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = new Bitmap(open.FileName);
                // image file path
                _BitmapOriginal = (Bitmap)pictureBox1.Image;
                ReduceColors();
                GetColors();
                //must select which colors to reduce
                ColorFilter();
                tickEnd = DateTime.Now.Ticks;
            }
            TimeSpan elapsedSpan = new TimeSpan((tickEnd - tickBegin));
            //string ticks = (tickEnd - tickBegin).ToString();
            MessageBox.Show(string.Format("{0:N0} Mins. {1:N0} Secs.", elapsedSpan.TotalMinutes, elapsedSpan.TotalSeconds));
        }
        private void ReduceColors()
        {
            
            try
            {
                if (_BitmapOriginal != null)
                {
                    Bitmap newBitmap = _BitmapOriginal;
                    //default pallete size 
                    var palleteSize = 16;

                    if (textBox1.Text != "")
                        palleteSize = Convert.ToInt32(textBox1.Text); //add exception handling
                    var ciq = new ColorImageQuantizer(new MedianCutQuantizer());
                    _BitmapOriginal = (Bitmap)pictureBox1.Image;

                    // get desired color palette for a given image
                    _ColorTable = ciq.CalculatePalette(newBitmap, palleteSize);
                    var reduceColorsBitmap = ciq.ReduceColors(newBitmap,
                        palleteSize);
                    var current = new Bitmap(reduceColorsBitmap);

                    //Assigning reduced color bitmap to _BitmapFinal, which can be used further
                    _BitmapReduce = current;
                    pictureBox1.Image = (current);
                    FiltersListBox.Items.Add("Reduce colors");

                }
                else
                {
                    MessageBox.Show(@"load first");
                }
                 
               
            }
            catch (Exception )
            {

                MessageBox.Show(@"Load first");
            }
            
        }
        private void ColorFilter()
        {
            if (_BitmapReduce != null)
            {
                var bitmapImageToBitmap = new Bitmap(_BitmapReduce);
                //currently if the color listbox count isnt 0 and the one the user selected isnt...nothing?
                //we assign colorNumber to that index. so what we need to do is dynamically set
                //the color number for the first instance, then do what we need it to do
                if (ColorsListBox.Items.Count > 0)
                {
                    try
                    {

                        for (int i = 0; i < ColorsListBox.Items.Count; i++)
                        {
                            _ColorOperator.ExceptGivenColorFillImageWIthReplacementColor(bitmapImageToBitmap, _ColorTable[i], Color.White);
                            _BitmapColorFiltered = bitmapImageToBitmap;
                            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage; //<-fine for debugging but should only show for original size not stretching
                            pictureBox2.Image = bitmapImageToBitmap;
                            
                                MagicWand(); //assuming magic wand will return null when their are no more objects
                                BlobSeperator();
                                RotateImage();
                           
                               
                            
                            
                        }
                        MessageBox.Show(line);
                        //using (FileStream fileStream = File.Open("DataPoints.txt", FileMode.OpenOrCreate))
                        //{
                        //    using (StreamWriter writer = new StreamWriter(fileStream))
                        //    {
                        //        writer.Write(line);
                        //    }
                        //}

                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                        //MessageBox.Show(@"Get colors and select a color, application takes first color by default");
                    }
                }


                //Depricated
                //Get selected color form color list, if it is empty get from text box
                //if (ColorsListBox.Items.Count != 0 && ColorsListBox.SelectedIndex != -1)
                //{
                //    _ColornNumber = ColorsListBox.SelectedIndex;
                //}
                //else
                //{
                //    MessageBox.Show(@"Get colors and select a color, application takes first color by default");
                //}

                //_ColorOperator.ExceptGivenColorFillImageWIthReplacementColor(bitmapImageToBitmap, _ColorTable[_ColornNumber], Color.White);
                //_BitmapColorFiltered = bitmapImageToBitmap;
                //pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                //pictureBox2.Image = bitmapImageToBitmap;
            }
            else
            {
                MessageBox.Show(@"Reduce colors before color filtering");
            }
        }
        private void GetColors()
        {
            var bitmap = _BitmapReduce;
            try
            {

                if (!_ColorTable.Any())
                {
                    var pixelColorDetector = new ColorOperator();
                    _DictinctColorList = pixelColorDetector.GetDiscreetColorList(bitmap).ToArray();
                    foreach (var color in _DictinctColorList)
                        ColorsListBox.Items.Add("R: " + color.R + " G: " + color.G + " B: " + color.B);
                }
                else
                {
                    foreach (var color in _ColorTable)
                        ColorsListBox.Items.Add("R: " + color.R + " G: " + color.G + " B: " + color.B);
                }
            }catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        private void MagicWand()
        {
            
                try
                {

                    var bf = _BitmapMagicWand ?? _BitmapColorFiltered;

                    if (bf != null)
                    {
                        // create filter
                        var filter = new PointedColorFloodFill
                        {
                            FillColor = Color.FromArgb(150, 92, 92)
                        };

                        // configure the filter
                        var applyFloodFillBitmap = bf.Clone(new Rectangle(0, 0, bf.Width, bf.Height),
                            PixelFormat.Format24bppRgb);
                        for (var y = 0; y < applyFloodFillBitmap.Height; y++)
                        {
                            for (var x = 0; x < applyFloodFillBitmap.Width; x++)
                                //Try to find a first pixel in BitMap which is not white
                                if (applyFloodFillBitmap.GetPixel(x, y).ToArgb() !=
                                    Color.White
                                        .ToArgb())
                                {
                                    filter.StartingPoint = new IntPoint(x, y);
                                    // apply the flood filter from starting point
                                    filter.ApplyInPlace(applyFloodFillBitmap);
                                    var newCloneForApplyingMagicWand =
                                        applyFloodFillBitmap.Clone(
                                            new Rectangle(0, 0, applyFloodFillBitmap.Width, applyFloodFillBitmap.Height),
                                            applyFloodFillBitmap.PixelFormat);
                                    var thisButtonOutputBitmap = new Bitmap(applyFloodFillBitmap);

                                    _ColorOperator.ExceptGivenColorFillImageWIthReplacementColor(thisButtonOutputBitmap,
                                        thisButtonOutputBitmap.GetPixel(x, y), Color.Black);

                                    //Assign color filtered and replace image to Bitmapzoom to use in Blob filter
                                    _BitmapZoom = new Bitmap(thisButtonOutputBitmap);
                                
                                // create an instance of blob counter algorithm
                                BlobCounterBase blobCounterBase = new BlobCounter()
                                    {
                                        // set filtering options
                                        FilterBlobs = true,
                                        MinWidth = 1,
                                        MinHeight = 1,
                                        // set ordering options
                                        ObjectsOrder = ObjectsOrder.Size
                                    };
                                    // process binary image
                                    blobCounterBase.ProcessImage(thisButtonOutputBitmap);
                                    var blobs = blobCounterBase.GetObjectsInformation();


                                    var pointList =
                                        _ColorOperator.GetRectangleEdgePointsWithGivenColorOnBitMap(thisButtonOutputBitmap,
                                            thisButtonOutputBitmap.GetPixel(x, y));
                                    foreach (var point in pointList)
                                        pointListBox.Items.Add(point);

                                    var rectangle = blobs[0].Rectangle;
                                    var stringbox = "X:" + rectangle.X + "Y:" + rectangle.Y + "Height:" + rectangle.Height +
                                                    "Width:" + rectangle.Width;



                                    pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                                    pictureBox3.Image = thisButtonOutputBitmap;

                                    var co = new ColorOperator();

                                    nextthisButtonInputBitmap = new Bitmap(newCloneForApplyingMagicWand);

                                    co.ReplaceColor(nextthisButtonInputBitmap, filter.FillColor, Color.White);
                                    pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                                    pictureBox4.Image = nextthisButtonInputBitmap;

                                    _BitmapMagicWand = nextthisButtonInputBitmap;

                                //MessageBox.Show("Blob Selected");
                                    BlobSeperator();
                                    

                                }
                        
                    }

                    }
                    else if(bf == null)
                {
                    isMagicWandNull = true;
                }
                else
                {
                    MessageBox.Show(@"Apply color filter properly to apply magic wand");
                }
                }
                catch (Exception exception)
                {

                    MessageBox.Show(exception.Message);
                }
            
        }
        private void BlobSeperator()
        {
            
            var bitmap = _BitmapZoom;
            try
            {
                
                    if (bitmap != null)
                    {
                        var play = new Bitmap(bitmap);

                        // create filter
                        var filter = new ExtractBiggestBlob();
                        // apply the filter
                        var biggestBlobsImage = filter.Apply(play);
                        _BitmapRotate = biggestBlobsImage;

                        //pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;

                        pictureBox2.Width = biggestBlobsImage.Width;
                        pictureBox2.Height = biggestBlobsImage.Height;
                        // = PictureBoxSizeMode.AutoSize;
                        pictureBox2.Image = biggestBlobsImage;

                    // pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
                    // thread = new Thread(RotateImage);

                    //thread.Start();
                    //RotateImage();
                        
                    }
                    else
                    {
                        MessageBox.Show(@"Apply magic wand first and seperate blobs");

                    }
                
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
        }
        private void RotateImage()
        {
            //if(thread.IsAlive)
            //    thread.Join();
            var bitmap = _BitmapRotate;
            
            try
            {
                for (int i = 0; i < 360; i++)
                {
                    _Degrees = i;
                    // create filter - rotate for 30 degrees keeping original image size
                    var filter = new RotateBilinear(_Degrees, false);
                    // apply the filter
                    var newImage = filter.Apply(bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                        PixelFormat.Format24bppRgb));
                    //newImage.Height = temp_widheight;

                   // picBox.Height = newImage.Height;
                    //picBox.Width = newImage.Width;

                    _BitmapMeasure = new Bitmap(newImage);
                    //picBox.Image = newImage;
                    Measurer();
                }
               
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }

        }
        private void Measurer()
        {
            try
            {
               
                        Bitmap bitmap = new Bitmap(_BitmapMeasure);
                        List<Point> points = new List<Point>() { };
                        Point centerPoint = new Point(bitmap.Height / 2, bitmap.Width / 2);

                        for (int i = (int)centerPoint.Y; i < bitmap.Width - 1; i++)
                            if (bitmap.GetPixel(i, (int)centerPoint.X) != bitmap.GetPixel(i + 1, (int)centerPoint.X))
                                points.Add(new Point(i, (int)centerPoint.X));
                        
                        foreach (var point in points)
                            line += "X:" + point.X.ToString() + " Y:" + point.Y.ToString(); //pass values to int[] instead of string
                        
                    
                 
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }
        private void ClearStuff()
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            //textBox1.Text = null;
            textBox2.Text = null;
            FiltersListBox.Items.Clear();
            ColorsListBox.Items.Clear();

            _BitmapReduce = null;
            _BitmapColorFiltered = null;
            _BitmapMagicWand = null;
            _BitmapRotate = null;
            _DictinctColorList = new Color[] { };
            _ColorTable = new Color[] { };
            _BitmapOriginal = null;
        }
        #endregion
        
        #region Manual Functions
        private void ReduceColors_Click(object sender, EventArgs e)
        {
            if (_BitmapOriginal != null)
            {
                Bitmap newBitmap = _BitmapOriginal;
                //default pallete size 
                var palleteSize = 16;

                if (textBox1.Text.Trim() != "")
                    palleteSize = Convert.ToInt32(textBox1.Text); //add exception handling
                var ciq = new ColorImageQuantizer(new MedianCutQuantizer());
                _BitmapOriginal = (Bitmap) pictureBox1.Image ;

                // get desired color palette for a given image
                _ColorTable = ciq.CalculatePalette(newBitmap, palleteSize);
                var reduceColorsBitmap = ciq.ReduceColors(newBitmap,
                    palleteSize);
                var current = new Bitmap(reduceColorsBitmap);

                //Assigning reduced color bitmap to _BitmapFinal, which can be used further
                _BitmapReduce = current;
                pictureBox1.Image = (current);
                FiltersListBox.Items.Add("Reduce colors");
            }
            else
            {
                MessageBox.Show(@"Load first");
            }
        }
        private void ColorFilter_Click(object sender, EventArgs e)
        {
            if (_BitmapReduce != null)
            {
                var bitmapImageToBitmap = new Bitmap(_BitmapReduce);

               // Get selected color form color list, if it is empty get from text box



                if (ColorsListBox.Items.Count != 0 && ColorsListBox.SelectedIndex != -1)
                {
                    _ColornNumber = ColorsListBox.SelectedIndex;
                }
                else
                {
                    MessageBox.Show(@"Get colors and select a color, application takes first color by default");
                }

                _ColorOperator.ExceptGivenColorFillImageWIthReplacementColor(bitmapImageToBitmap, _ColorTable[_ColornNumber], Color.White);
                _BitmapColorFiltered = bitmapImageToBitmap;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.Image = bitmapImageToBitmap;
            }
            else
            {
                MessageBox.Show(@"Reduce colors before color filtering");
            }
        }
        //gets how many dif distinct rgb colors
        private void GetColors_Click(object sender, EventArgs e)
        {
            var bitmap = _BitmapReduce;

            if (!_ColorTable.Any())
            {
                var pixelColorDetector = new ColorOperator();
                _DictinctColorList = pixelColorDetector.GetDiscreetColorList(bitmap).ToArray();
                foreach (var color in _DictinctColorList)
                    ColorsListBox.Items.Add("R: " + color.R + " G: " + color.G + " B: " + color.B);
            }
            else
            {
                foreach (var color in _ColorTable)
                    ColorsListBox.Items.Add("R: " + color.R + " G: " + color.G + " B: " + color.B);
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            //ControlBox =false;
            //            TopMost = true;
           // FormBorderStyle = FormBorderStyle.SizableToolWindow;
          //  WindowState = FormWindowState.Maximized;
        }
        private void MagicWand_Click(object sender, EventArgs e)
        {
            var bf = _BitmapMagicWand ?? _BitmapColorFiltered;

            if (bf != null)
            {
                // create filter
                var filter = new PointedColorFloodFill
                {
                    FillColor = Color.FromArgb(150, 92, 92)
                };

                // configure the filter
                var applyFloodFillBitmap = bf.Clone(new Rectangle(0, 0, bf.Width, bf.Height),
                    PixelFormat.Format24bppRgb);
                for (var y = 0; y < applyFloodFillBitmap.Height; y++)
                for (var x = 0; x < applyFloodFillBitmap.Width; x++)
                    //Try to find a first pixel in BitMap which is not white
                    if (applyFloodFillBitmap.GetPixel(x, y).ToArgb() !=
                        Color.White
                            .ToArgb())
                    {
                        filter.StartingPoint = new IntPoint(x, y);
                        // apply the flood filter from starting point
                        filter.ApplyInPlace(applyFloodFillBitmap);
                        var newCloneForApplyingMagicWand =
                            applyFloodFillBitmap.Clone(
                                new Rectangle(0, 0, applyFloodFillBitmap.Width, applyFloodFillBitmap.Height),
                                applyFloodFillBitmap.PixelFormat);
                        var thisButtonOutputBitmap = new Bitmap(applyFloodFillBitmap);

                        _ColorOperator.ExceptGivenColorFillImageWIthReplacementColor(thisButtonOutputBitmap,
                            thisButtonOutputBitmap.GetPixel(x, y), Color.Black);

                        //Assign color filtered and replace image to Bitmapzoom to use in Blob filter
                        _BitmapZoom = new Bitmap(thisButtonOutputBitmap);

                        // create an instance of blob counter algorithm
                        BlobCounterBase blobCounterBase = new BlobCounter()
                        {
                            // set filtering options
                            FilterBlobs = true,
                            MinWidth = 1,
                            MinHeight = 1,
                            // set ordering options
                            ObjectsOrder = ObjectsOrder.Size
                        };
                        // process binary image
                        blobCounterBase.ProcessImage(thisButtonOutputBitmap);
                        var blobs = blobCounterBase.GetObjectsInformation();


                        var pointList =
                            _ColorOperator.GetRectangleEdgePointsWithGivenColorOnBitMap(thisButtonOutputBitmap,
                                thisButtonOutputBitmap.GetPixel(x, y));
                        foreach (var point in pointList)
                            pointListBox.Items.Add(point);

                        var rectangle = blobs[0].Rectangle;
                        var stringbox = "X:" + rectangle.X + "Y:" + rectangle.Y + "Height:" + rectangle.Height +
                                        "Width:" + rectangle.Width;

                       

                        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox3.Image = thisButtonOutputBitmap;

                        var co = new ColorOperator();
                        var nextthisButtonInputBitmap = new Bitmap(newCloneForApplyingMagicWand);

                        co.ReplaceColor(nextthisButtonInputBitmap, filter.FillColor, Color.White);
                        pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox4.Image = nextthisButtonInputBitmap;

                        _BitmapMagicWand = nextthisButtonInputBitmap;
                        
                        return;
                    }
            }
            else
                MessageBox.Show(@"Apply color filter properly to apply magic wand");
        }
        private void BlobSeperator_Click(object sender, EventArgs e)
        {
            var bitmap = _BitmapZoom;
            if (bitmap != null)
            {
                var play = new Bitmap(bitmap);

                // create filter
                var filter = new ExtractBiggestBlob();
                // apply the filter
                var biggestBlobsImage = filter.Apply(play);
                _BitmapRotate = biggestBlobsImage;

                //pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;

                pictureBox2.Width = biggestBlobsImage.Width;
                pictureBox2.Height = biggestBlobsImage.Height;
                // = PictureBoxSizeMode.AutoSize;
                pictureBox2.Image = biggestBlobsImage;

               // pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            }

            else
            {
                MessageBox.Show(@"Apply magic wand first and seperate blobs");
            }
        }
        private void RotateImage_Click(object sender, EventArgs e)
        {
            var bitmap = _BitmapRotate;
            if (textBox2.Text != "")
                _Degrees = Convert.ToInt32(textBox2.Text);
            else
                _Degrees += 1;
            // create filter - rotate for 30 degrees keeping original image size
            var filter = new RotateBilinear(_Degrees, false);
            // apply the filter
            var newImage = filter.Apply(bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                PixelFormat.Format24bppRgb));
            //newImage.Height = temp_widheight;

                                    pictureBox3.Height = newImage.Height;
                                    pictureBox3.Width = newImage.Width;
         
            _BitmapMeasure = new Bitmap(newImage);
            pictureBox3.Image = newImage;
            

        }
        private void SaveImage_Click(object sender, EventArgs e)
        {

            SaveFileDialog open = new SaveFileDialog
            {
                RestoreDirectory = true,
                Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp"
            };
            // image filters
            if (open.ShowDialog() == DialogResult.OK)
            {
                Bitmap current;

                if (pictureBox3.Image!= null)
                {
                     current = (Bitmap)pictureBox3.Image;
                }
                else if(pictureBox2.Image != null)
                {
                    current = (Bitmap)pictureBox2.Image;
                }
                else
                {
                    current = (Bitmap)pictureBox1.Image;
                }
                open.FileName =  open.FileName ;
               current.Save(open.FileName);
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            ClearStuff();

        }
        private void Measurer_Click(object sender, EventArgs e)
        {

            Bitmap bitmap = new Bitmap(_BitmapMeasure);
            List<Point> points = new List<Point>() { };
            Point centerPoint = new Point(bitmap.Height / 2, bitmap.Width / 2);

            for (int i = (int)centerPoint.Y; i < bitmap.Width - 1; i++)
            {


                if (bitmap.GetPixel(i, (int)centerPoint.X) != bitmap.GetPixel(i + 1, (int)centerPoint.X))
                {

                    points.Add(new Point(i, (int)centerPoint.X));
                }

            }

            //pointListBox.Items.Clear();

            foreach (var point in points)
            {
                pointListBox.Items.Add("X:" + point.X + "Y" + point.Y);
            }

        }










        #endregion

        


       
    }
}
