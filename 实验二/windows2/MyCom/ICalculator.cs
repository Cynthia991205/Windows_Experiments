using System;

using System.Runtime.InteropServices;

namespace MyCom
{
	//接口定义
	[Guid("52CD62AE-BCEA-47E4-81DC-B1EA37D1673E")]
	[ComVisible(true)]
	public interface ICalculator
	{
		[DispId(1)]
		String Add(int num1, int num2);
		String Subtract(int num1, int num2);
		String Multiply(int num1, int num2);
		String Divide(double num1, double num2);
	}
}
