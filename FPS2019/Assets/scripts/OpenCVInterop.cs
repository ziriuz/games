using System.Runtime.InteropServices;

// Define the functions which can be called from the .dll.
internal static class OpenCVInterop
{
    [DllImport("FaceTracker")]
    internal static extern int Init(ref int outCameraWidth, ref int outCameraHeight);

    [DllImport("FaceTracker")]
    internal static extern int Close();

    [DllImport("FaceTracker")]
    internal static extern int SetScale(int downscale);

    [DllImport("FaceTracker")]
    internal static extern unsafe void Detect(CvCircle* outFaces, int maxOutFacesCount, ref int outDetectedFacesCount);
}

// Define the structure to be sequential and with the correct byte size (3 ints = 4 bytes * 3 = 12 bytes)
[StructLayout(LayoutKind.Sequential, Size = 12)]
public struct CvCircle
{
    public int X, Y, Radius;
}