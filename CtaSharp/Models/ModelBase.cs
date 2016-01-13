using System;

namespace CtaSharp
{
	public abstract class ModelBase<T>
	{
		public DateTime UpdatedTime { get; protected set; }

		public ModelBase ()
		{
			this.UpdatedTime = DateTime.Now;
		}

		internal abstract void UpdateWith(T obj);
	}
}

