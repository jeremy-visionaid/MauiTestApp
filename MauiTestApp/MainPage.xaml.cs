using System.Diagnostics;
using AVFoundation;
using CoreFoundation;
using CoreMedia;

namespace MauiTestApp;

sealed class VideoCaptureDelegate : AVCaptureVideoDataOutputSampleBufferDelegate
{
    public override void DidOutputSampleBuffer(AVCaptureOutput captureOutput, CMSampleBuffer sampleBuffer, AVCaptureConnection connection)
    {
        Debugger.Break();
    }
}

public partial class MainPage : ContentPage
{
	AVCaptureSession? captureSession;
	VideoCaptureDelegate? videoCaptureDelegate;
	AVCaptureVideoDataOutput? videoDataOutput;
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        captureSession = new AVCaptureSession();
        captureSession.BeginConfiguration();
        videoCaptureDelegate = new VideoCaptureDelegate();

        var videoDevice = AVCaptureDevice.GetDefaultDevice(AVMediaTypes.Video);
        if (videoDevice == null)
        {
            Debug.WriteLine("No video device found");
            return;
        }

        var videoInput = AVCaptureDeviceInput.FromDevice(videoDevice);
        if (videoInput == null)
        {
            Debug.WriteLine("Failed to create video input");
            return;
        }

        if (!captureSession.CanAddInput(videoInput))
        {
            Debug.WriteLine("Cannot add video input to capture session");
            return;
        }

        captureSession.AddInput(videoInput);

        videoDataOutput = new AVCaptureVideoDataOutput();
        videoDataOutput.AlwaysDiscardsLateVideoFrames = true;
        videoDataOutput.SetSampleBufferDelegate(videoCaptureDelegate, DispatchQueue.MainQueue);

        if (!captureSession.CanAddOutput(videoDataOutput))
        {
            Debug.WriteLine("Failed to add video output");
            return;
        }

        captureSession.AddOutput(videoDataOutput);

        captureSession.CommitConfiguration();
        captureSession.StartRunning();
        Debug.WriteLine("Video capture started");
    }
}
