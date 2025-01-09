using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CameraProcess
{
    public class Camera
    {
        private Thread cameraThread;
        private Thread triggerThread;
        public bool State { get; set; }
        private bool Trigger { get; set; }

        public Camera()
        {
            State = false;
            Trigger = false;
        }

        public void Start()
        {
            State = true;

            if (triggerThread != null && triggerThread.IsAlive)
                return;
            triggerThread = new Thread(() => TriggerProcess());
            triggerThread.Start();

            if (cameraThread != null && cameraThread.IsAlive)
                return;
            cameraThread = new Thread(() => CameraProcess());
            cameraThread.Start();
        }

        public void Stop()
        {
            State = false;
            Thread.Sleep(100);
        }

        private void TriggerProcess()
        {
            while (true)
            {
                if (State)
                {
                    Trigger = true;
                    Thread.Sleep(990);
                }
                else
                {
                    break;
                }

                Thread.Sleep(10);
            }
        }

        private void CameraProcess()
        {
            int frameCounter = 0;

            while (true)
            {
                if (State)
                {
                    if (Trigger)
                    {
                        VideoCapture video = VideoCapture.FromCamera(0);
                        Mat frame = new Mat();

                        if (video.IsOpened())
                        {
                            if (video.Read(frame))
                            {
                                if (!frame.Empty())
                                {
                                    Mat m_croppedImage = new Mat(frame, new Rect(338, 248, 612, 275));
                                    Cv2.ImWrite("images_" + frameCounter.ToString() + "_" + ".bmp", m_croppedImage);

                                    m_croppedImage.Release();
                                    frameCounter++;
                                }
                            }
                        }

                        frame.Release();
                        Trigger = false;
                    }
                }
                else
                {
                    Trigger = false;
                    break;
                }

                Thread.Sleep(1);
            }
        }
    }
}
