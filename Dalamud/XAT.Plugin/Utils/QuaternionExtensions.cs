﻿using System;
using System.Numerics;

namespace XAT.Plugin.Utils;

public static class QuaternionExtensions
{
    public static Vector3 ToYawPitchRoll(this Quaternion r)
    {
        float yaw = MathF.Atan2(2.0f * (r.Y * r.W + r.X * r.Z), 1.0f - 2.0f * (r.X * r.X + r.Y * r.Y));
        float pitch = MathF.Asin(2.0f * (r.X * r.W - r.Y * r.Z));
        float roll = MathF.Atan2(2.0f * (r.X * r.Y + r.Z * r.W), 1.0f - 2.0f * (r.X * r.X + r.Z * r.Z));

        return new Vector3(yaw, pitch, roll);
    }

    public static Vector3 RotatePosition(this Quaternion left, Vector3 right)
    {
        float num = left.X * 2f;
        float num2 = left.Y * 2f;
        float num3 = left.Z * 2f;
        float num4 = left.X * num;
        float num5 = left.Y * num2;
        float num6 = left.Z * num3;
        float num7 = left.X * num2;
        float num8 = left.X * num3;
        float num9 = left.Y * num3;
        float num10 = left.W * num;
        float num11 = left.W * num2;
        float num12 = left.W * num3;
        float x = ((1f - (num5 + num6)) * right.X) + ((num7 - num12) * right.Y) + ((num8 + num11) * right.Z);
        float y = ((num7 + num12) * right.X) + ((1f - (num4 + num6)) * right.Y) + ((num9 - num10) * right.Z);
        float z = ((num8 - num11) * right.X) + ((num9 + num10) * right.Y) + ((1f - (num4 + num5)) * right.Z);
        return new Vector3(x, y, z);
    }
}
