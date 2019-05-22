using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenCvSharp;
using OpenCvSharp.ML;

using Tesseract;

using TensorFlow;


using System.Globalization;
using System.IO;






namespace opencv_001
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        VideoCapture videoCapture;

        SimpleOCR simpleOCR;
        KNearest kNearestTrainData;

        int getX_point, getY_point, getWidth, getHeight;
        double Val_thresh, Val_threshMaxVal;
        private void Form1_Load(object sender, EventArgs e)
        {
            videoCapture = new VideoCapture(1);
            //  videoCapture.Set(CaptureProperty.FrameWidth, 320);
            //  videoCapture.Set(CaptureProperty.FrameHeight, 240);
            //  log_1.Text = Convert.ToString(videoCapture.FrameWidth) + "\r\n" + log_1.Text;
            //  log_1.Text = Convert.ToString(videoCapture.FrameHeight) + "\r\n" + log_1.Text;

            targetWidthVal.Text = "100";
            targetHeightVal.Text = "30";

            xVal.Text = Convert.ToString( (videoCapture.FrameWidth - Convert.ToInt32(targetWidthVal.Text)) / 2 );
            yVal.Text = Convert.ToString((videoCapture.FrameHeight - Convert.ToInt32(targetHeightVal.Text)) / 2);


            thresh.Text = "10";
            threshMaxVal.Text = "255";
        }




        private void Button1_Click(object sender, EventArgs e)
        {   
            if (xVal.Text.Length == 0)
            {
                xVal.Text = "0";
            }
            getX_point = Convert.ToInt32(xVal.Text);
            if (getX_point < 0)
            {
                getX_point = 0;
            }

            if (yVal.Text.Length == 0)
            {
                yVal.Text = "0";
            }
            getY_point = Convert.ToInt32(yVal.Text);
            if (getY_point < 0)
            {
                getY_point = 0;
            }


            if (targetWidthVal.Text.Length == 0)
            {
                targetWidthVal.Text = "100";
            }
            getWidth = Convert.ToInt32(targetWidthVal.Text);
            if (getWidth < 80)
            {
                getWidth = 80;
            }
            if (getWidth > videoCapture.FrameWidth)
            {
                getWidth = (videoCapture.FrameWidth - 50);
            }

            if (targetHeightVal.Text.Length == 0)
            {
                targetHeightVal.Text = "30";
            }
            getHeight = Convert.ToInt32(targetHeightVal.Text);
            if (getHeight < 20)
            {
                getHeight = 20;
            }
            if (getHeight > videoCapture.FrameHeight)
            {
                getHeight = (videoCapture.FrameHeight - 20);
            }

            Val_thresh = Convert.ToDouble(thresh.Text);
            Val_threshMaxVal = Convert.ToDouble(threshMaxVal.Text);

            log_1.Text = null;
            
            timer1.Interval = 500; //스케쥴 간격을 5초로 준 것이다.
            timer1.Stop();
            timer1.Start(); //타이머를 발동시킨다.
        }


        private void Timer1_Tick(object sender, EventArgs e)
        {
            

            Mat frame_img_source_01 = new Mat();
            videoCapture.Read(frame_img_source_01);

            int x1 = getX_point;
            int x2 = x1 + getWidth;

            int y1 = getY_point;
            int y2 = y1 + getHeight;


            for(int i=0; i<6; i++)
            {
                x2 = getX_point + ( (getWidth / 6) * (i+1) ) ;

                Cv2.Rectangle(
                    frame_img_source_01
                    , new OpenCvSharp.Point(x1, y1)
                    , new OpenCvSharp.Point(x2, y2)
                    , Scalar.Red
                    , 1
                    );
            }
            
















            pictureBox1.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame_img_source_01);

            //  그레이 스케일
            Mat frame_img_source_02 = new Mat();
            videoCapture.Read(frame_img_source_02);
            Mat frame_img_gray = new Mat();
            byte[] imageBytes = frame_img_source_02.ToBytes(".bmp");
            //byte[] imageBytes = frame_img_FlipY.ToBytes(".bmp");
            frame_img_gray = Mat.FromImageData(imageBytes, ImreadModes.Grayscale);
            pictureBox2.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame_img_gray);


            //  윤곽선 출력 처리
            Mat frame_img_outLine_01 = new Mat();
            Cv2.Canny(frame_img_gray, frame_img_outLine_01, Val_thresh, Val_threshMaxVal);
            pictureBox3.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame_img_outLine_01);
            
            


            //  인식대상 이미지 생성
            Mat frame_img_source_03 = new Mat();
            videoCapture.Read(frame_img_source_03);

            // 상단 지우기
            Cv2.Rectangle(frame_img_source_03, new OpenCvSharp.Point(0, 0), new OpenCvSharp.Point(640, y1), Scalar.White, -1 );
            
            // 하단 지우기
            Cv2.Rectangle(frame_img_source_03, new OpenCvSharp.Point(0, y2), new OpenCvSharp.Point(640, 480), Scalar.White, -1);

            //  좌측 지우기
            Cv2.Rectangle(frame_img_source_03, new OpenCvSharp.Point(0, 0), new OpenCvSharp.Point(x1, 480), Scalar.White, -1);

            //  우측 지우기
            Cv2.Rectangle(frame_img_source_03, new OpenCvSharp.Point(x2, 0), new OpenCvSharp.Point(640, 480), Scalar.White, -1);


            log_1.Text = "\r\n" + Convert.ToString(DateTime.Now) + "-TesseractOCR-" + TesseractOCR(frame_img_source_03) + log_1.Text;






            /*

            Cv2.Threshold(frame_img_source_03, frame_img_source_03, 150, 255, ThresholdTypes.BinaryInv);
            Cv2.FastNlMeansDenoising(frame_img_source_03, frame_img_source_03, 50);
            Cv2.FastNlMeansDenoising(frame_img_source_03, frame_img_source_03, 50);
            Mat kernel2 = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(2, 2));
            Cv2.Dilate(frame_img_source_03, frame_img_source_03, kernel2);
            Cv2.Threshold(frame_img_source_03, frame_img_source_03, 150, 255, ThresholdTypes.BinaryInv);


            //pictureBox4.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame_img_source_03);

            simpleOCR = new SimpleOCR();
            var trainingImages = simpleOCR.ReadTrainingImages("C://Users//dev-yym//source//repos//opencv_001//Numbers_dit", "*.png");
            //var trainingImages = simpleOCR.ReadTrainingImages("C://Users//dev-yym//source//repos//opencv_001//Numbers", "*.png");
            kNearestTrainData = simpleOCR.TrainData(trainingImages);
            log_2.Text = "\r\n" + Convert.ToString(DateTime.Now) + "-simpleOCR-" + simpleOCR.DoOCR_ReturnString(kNearestTrainData, frame_img_source_03) + log_2.Text;
            */

            /*
            Mat kernel2 = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(2, 2));
            Cv2.Dilate(frame_img_Threshold, frame_img_Threshold, kernel2);
            log.Text = log.Text + "\r\n-처리내용: Dilate";
            pictureBox4.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame_img_Threshold);
            log.Text = log.Text + "\r\n-처리내용: 처리된 이미지 출력";

            //------------------------------------------------------------------------------------------------------------------------------

            log.Text = log.Text + "\r\n-처리내용: Tesseract OCR 작업 개시";
            Bitmap fromOpenCV = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame_img_Threshold);
            TesseractEngine engine = new TesseractEngine("./tessdata", "lets", EngineMode.Default);
            Page page = engine.Process(fromOpenCV);
            log.Text = log.Text + "\r\n-처리내용: Tesseract OCR 작업 결과 : " + page.GetText();

            //------------------------------------------------------------------------------------------------------------------------------
            */

            /*
            //  설정된 크기 사각형 찾기
            Mat frame_img_source_04 = new Mat();
            videoCapture.Read(frame_img_source_04);

            Mat frame_img_displayRect = new Mat();
            videoCapture.Read(frame_img_displayRect);

            Mat frame_img_Ocr_source = new Mat();

            MSER mser = MSER.Create();
            OpenCvSharp.Point[][] contours;
            OpenCvSharp.Rect[] bboxes;
            mser.DetectRegions(frame_img_source_04, out contours, out bboxes);

            int RectCnt = 0;
            for (var i = 0; bboxes.Length > i; i++)
            {
                if ((bboxes[i].Width > 60) && (bboxes[i].Height > 30))
                {
                    if (bboxes[i].Width >= (bboxes[i].Height * 2))
                    {
                        RectCnt = RectCnt + 1;
                        frame_img_Ocr_source = frame_img_source_04[bboxes[i]];


                        Cv2.Rectangle(frame_img_displayRect, bboxes[i], Scalar.Green, 2);
                        pictureBox4.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame_img_displayRect);
                        
                        log_1.Text = "\r\n"+ Convert.ToString(DateTime.Now) + "-TesseractOCR-" + TesseractOCR(frame_img_Ocr_source) + log_1.Text;

                        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        /*
                        Cv2.Threshold(frame_img_Ocr_source, frame_img_Ocr_source, 120, 255, ThresholdTypes.BinaryInv);
                        Cv2.FastNlMeansDenoising(frame_img_Ocr_source, frame_img_Ocr_source, 50);
                        Cv2.FastNlMeansDenoising(frame_img_Ocr_source, frame_img_Ocr_source, 50);
                        Cv2.FastNlMeansDenoising(frame_img_Ocr_source, frame_img_Ocr_source, 50);
                        Mat kernel2 = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(2, 2));
                        Cv2.Dilate(frame_img_Ocr_source, frame_img_Ocr_source, kernel2);
                        Cv2.Threshold(frame_img_Ocr_source, frame_img_Ocr_source, 150, 255, ThresholdTypes.BinaryInv);

                        simpleOCR = new SimpleOCR();
                        var trainingImages = simpleOCR.ReadTrainingImages("C://Users//dev-yym//source//repos//opencv_001//Numbers_dit", "*.png");
                        //var trainingImages = simpleOCR.ReadTrainingImages("C://Users//dev-yym//source//repos//opencv_001//Numbers", "*.png");
                        kNearestTrainData = simpleOCR.TrainData(trainingImages);
                        log_2.Text = "\r\n" + Convert.ToString(DateTime.Now) + "-simpleOCR-" + simpleOCR.DoOCR_ReturnString(kNearestTrainData, frame_img_Ocr_source) + log_2.Text;
                        

                    }
                }
            }
            */

        }


        private String TesseractOCR(Mat OcrTargetData)
        {
            String Rtn_OCR_Data = null;


            //  그레이 스케일
            Mat frame_img_gray = new Mat();
            byte[] imageBytes_01 = OcrTargetData.ToBytes(".bmp");
            frame_img_gray = Mat.FromImageData(imageBytes_01, ImreadModes.Grayscale);

            Mat frame_img_Threshold = new Mat();
            

            Cv2.Threshold(frame_img_gray, frame_img_Threshold, Val_thresh, Val_threshMaxVal, ThresholdTypes.BinaryInv);
            
            
            for (int k = 0; k < 1; k++)
            {
                Cv2.FastNlMeansDenoising(frame_img_Threshold, frame_img_Threshold, 50);
            }
            

            Mat kernel2 = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(2, 2));
            Cv2.Dilate(frame_img_Threshold, frame_img_Threshold, kernel2);

            pictureBox4.Image = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame_img_Threshold);

            Bitmap fromOpenCV = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(frame_img_Threshold);
            //TesseractEngine engine = new TesseractEngine("./tessdata", "lets", EngineMode.Default);
            TesseractEngine engine = new TesseractEngine("./tessdata", "segment7", EngineMode.Default);

            

            Page page = engine.Process(fromOpenCV);

            Rtn_OCR_Data    =   page.GetText();

            return Rtn_OCR_Data;
        }


    }



    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////



    public class ImageInfo
    {
        public Mat Image { set; get; }
        public int ImageGroupId { set; get; }
        public int ImageId { set; get; }
    }

    public class SimpleOCR
    {

        private const double Thresh = 80;
        private const double ThresholdMaxVal = 255;


        public IList<ImageInfo> ReadTrainingImages(string path, string ext)
        {
            var images = new List<ImageInfo>();

            var imageId = 1;
            foreach (var dir in new DirectoryInfo(path).GetDirectories())
            {
                var groupId = int.Parse(dir.Name);
                foreach (var imageFile in dir.GetFiles(ext))
                {
                    var image = processTrainingImage(new Mat(imageFile.FullName, ImreadModes.Grayscale));
                    if (image == null)
                    {
                        continue;
                    }

                    images.Add(new ImageInfo
                    {
                        Image = image,
                        ImageId = imageId++,
                        ImageGroupId = groupId
                    });
                }
            }

            return images;
        }

        private static Mat processTrainingImage(Mat gray)
        {
            var threshImage = new Mat();
            Cv2.Threshold(gray, threshImage, Thresh, ThresholdMaxVal, ThresholdTypes.BinaryInv); // Threshold to find contour

            OpenCvSharp.Point[][] contours;
            HierarchyIndex[] hierarchyIndexes;
            Cv2.FindContours(
                threshImage,
                out contours,
                out hierarchyIndexes,
                mode: RetrievalModes.CComp,
                method: ContourApproximationModes.ApproxSimple);

            if (contours.Length == 0)
            {
                return null;
            }

            Mat result = null;

            var contourIndex = 0;
            while ((contourIndex >= 0))
            {
                var contour = contours[contourIndex];

                var boundingRect = Cv2.BoundingRect(contour); //Find bounding rect for each contour
                var roi = new Mat(threshImage, boundingRect); //Crop the image

                //Cv2.ImShow("src", gray);
                //Cv2.ImShow("roi", roi);
                //Cv.WaitKey(0);

                var resizedImage = new Mat();
                var resizedImageFloat = new Mat();
                Cv2.Resize(roi, resizedImage, new OpenCvSharp.Size(10, 10)); //resize to 10X10
                resizedImage.ConvertTo(resizedImageFloat, MatType.CV_32FC1); //convert to float
                result = resizedImageFloat.Reshape(1, 1);

                contourIndex = hierarchyIndexes[contourIndex].Next;
            }

            return result;
        }

        public KNearest TrainData(IList<ImageInfo> trainingImages)
        {
            var samples = new Mat();
            foreach (var trainingImage in trainingImages)
            {
                samples.PushBack(trainingImage.Image);
            }

            var labels = trainingImages.Select(x => x.ImageGroupId).ToArray();
            var responses = new Mat(labels.Length, 1, MatType.CV_32SC1, labels);
            var tmp = responses.Reshape(1, 1); //make continuous
            var responseFloat = new Mat();
            tmp.ConvertTo(responseFloat, MatType.CV_32FC1); // Convert  to float

            var kNearest = KNearest.Create();
            kNearest.Train(samples, SampleTypes.RowSample, responseFloat); // Train with sample and responses
            return kNearest;
        }
        
        public Mat DoOCR(KNearest kNearest, Mat src)
        {

            var gray = new Mat();
            Cv2.CvtColor(src, gray, ColorConversionCodes.BGRA2GRAY);

            var threshImage = new Mat();
            Cv2.Threshold(gray, threshImage, Thresh, ThresholdMaxVal, ThresholdTypes.BinaryInv); // Threshold to find contour



            OpenCvSharp.Point[][] contours;
            HierarchyIndex[] hierarchyIndexes;
            Cv2.FindContours(
                threshImage,
                out contours,
                out hierarchyIndexes,
                mode: RetrievalModes.CComp,
                method: ContourApproximationModes.ApproxSimple);


            if (contours.Length == 0)
            {
                //throw new NotSupportedException("Couldn't find any object in the image.");
                return null;
            }


            //Create input sample by contour finding and cropping
            var dst = new Mat(src.Rows, src.Cols, MatType.CV_8UC3, Scalar.All(0));

            var contourIndex = 0;
            while ((contourIndex >= 0))
            {
                var contour = contours[contourIndex];

                var boundingRect = Cv2.BoundingRect(contour); //Find bounding rect for each contour

                Cv2.Rectangle(src,
                    new OpenCvSharp.Point(boundingRect.X, boundingRect.Y),
                    new OpenCvSharp.Point(boundingRect.X + boundingRect.Width, boundingRect.Y + boundingRect.Height),
                    new Scalar(0, 0, 255),
                    2);

                var roi = new Mat(threshImage, boundingRect); //Crop the image

                var resizedImage = new Mat();
                var resizedImageFloat = new Mat();
                Cv2.Resize(roi, resizedImage, new OpenCvSharp.Size(10, 10)); //resize to 10X10
                resizedImage.ConvertTo(resizedImageFloat, MatType.CV_32FC1); //convert to float
                var result = resizedImageFloat.Reshape(1, 1);


                var results = new Mat();
                var neighborResponses = new Mat();
                var dists = new Mat();
                var detectedClass = (int)kNearest.FindNearest(result, 1, results, neighborResponses, dists);
                
                Cv2.PutText(
                    dst,
                    detectedClass.ToString(CultureInfo.InvariantCulture),
                    new OpenCvSharp.Point(boundingRect.X, boundingRect.Y + boundingRect.Height),
                    0,
                    1,
                    new Scalar(0, 255, 0),
                    2);

                contourIndex = hierarchyIndexes[contourIndex].Next;
            }

            return dst;

        }


        public String DoOCR_ReturnString(KNearest kNearest, Mat src)
        {
            String RtnString = null;


            var gray = new Mat();
            Cv2.CvtColor(src, gray, ColorConversionCodes.BGRA2GRAY);

            var threshImage = new Mat();
            Cv2.Threshold(gray, threshImage, Thresh, ThresholdMaxVal, ThresholdTypes.BinaryInv); // Threshold to find contour



            OpenCvSharp.Point[][] contours;
            HierarchyIndex[] hierarchyIndexes;
            Cv2.FindContours(
                threshImage,
                out contours,
                out hierarchyIndexes,
                mode: RetrievalModes.CComp,
                method: ContourApproximationModes.ApproxSimple);


            if (contours.Length == 0)
            {
                //throw new NotSupportedException("Couldn't find any object in the image.");
                return null;
            }


            //Create input sample by contour finding and cropping
            var dst = new Mat(src.Rows, src.Cols, MatType.CV_8UC3, Scalar.All(0));

            var contourIndex = 0;
            while ((contourIndex >= 0))
            {
                var contour = contours[contourIndex];

                var boundingRect = Cv2.BoundingRect(contour); //Find bounding rect for each contour

                Cv2.Rectangle(src,
                    new OpenCvSharp.Point(boundingRect.X, boundingRect.Y),
                    new OpenCvSharp.Point(boundingRect.X + boundingRect.Width, boundingRect.Y + boundingRect.Height),
                    new Scalar(0, 0, 255),
                    2);

                var roi = new Mat(threshImage, boundingRect); //Crop the image

                var resizedImage = new Mat();
                var resizedImageFloat = new Mat();
                Cv2.Resize(roi, resizedImage, new OpenCvSharp.Size(10, 10)); //resize to 10X10
                resizedImage.ConvertTo(resizedImageFloat, MatType.CV_32FC1); //convert to float
                var result = resizedImageFloat.Reshape(1, 1);


                var results = new Mat();
                var neighborResponses = new Mat();
                var dists = new Mat();
                var detectedClass = (int)kNearest.FindNearest(result, 1, results, neighborResponses, dists);

                RtnString = RtnString + detectedClass.ToString(CultureInfo.InvariantCulture);

                contourIndex = hierarchyIndexes[contourIndex].Next;
            }


            return RtnString;
        }




    }

}
