using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.ObjetosTablero.Proyectiles
{
	public class Observable
	{
		public List<Observer> Observers { get; set; }

		public void AddObserver(Observer observer)
		{
			Observers.Add(observer);
		}

		public void NotifyAll()
		{
			foreach (var item in Observers)
			{
				item.Update();
			}
		}
	}
}
