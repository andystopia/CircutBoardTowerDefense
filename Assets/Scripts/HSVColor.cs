using System;
using UnityEngine;

/// <summary>
/// Represents a HSV Color
/// </summary>
public readonly struct HSVColor
{
   [Range(0, 360)]
   private readonly float hue;
   [Range(0, 1)]
   private readonly float saturation;
   [Range(0, 1)]
   private readonly float value;


   /// <summary>
   /// Constructs a new HSV Color
   /// 
   /// </summary>
   /// <param name="hue">[0, 360]</param>
   /// <param name="saturation">[0, 1]</param>
   /// <param name="value">[0, 1]</param>
   /// <exception cref="ArgumentException"></exception>
   public HSVColor(float hue, float saturation, float value)
   {
      if (hue < 0 || hue > 360 || saturation < 0 || saturation > 1 || value < 0 || value > 1)
      {
         // FIXME: better error.
         throw new ArgumentException($"Arguments passed to HSV Color are out of range");
      }
      
      this.hue = hue;
      this.saturation = saturation;
      this.value = value;
   }

   /// <summary>
   /// Creates an HSV Color from an RGB one.
   /// </summary>
   /// <param name="color"></param>
   public HSVColor(Color color)
   {
      Color.RGBToHSV(color, out hue, out saturation, out value);
   }
   
   
   /// <summary>
   /// Creates an HSV Color from an RGB one.
   /// </summary>
   /// <param name="hsvColor"></param>
   public HSVColor(Vector3 hsvColor)
   {
      hue = hsvColor.x;
      saturation = hsvColor.y;
      value = hsvColor.z;
   }
   

   /// <summary>
   /// Provides a vector from the
   /// given instance.
   ///
   /// The values of the vector
   /// are the hue saturation and value.
   ///
   /// If you need an RGB Vector,
   /// convert to a unity color first,
   /// and then convert that to a vector.
   /// </summary>
   /// <returns></returns>
   public Vector3 AsVector()
   {
      return new Vector3(hue, saturation, value);
   }
   
   /// <summary>
   /// Convert to a Unity Color
   ///
   /// Process can be found on Wikipedia.
   /// </summary>
   /// <param name="color"></param>
   /// <returns></returns>
   public static implicit operator Color(HSVColor color)
   {
      return Color.HSVToRGB(color.hue, color.saturation, color.value);
   }
}
