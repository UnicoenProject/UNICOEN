namespace UniUni.Text.Gauche {
	public class GuessDfa {
		public sbyte[,] States { get; set; }
		public GuessArc[] Arcs { get; set; }
		public int State { get; set; }
		public double Score { get; set; }
	}
}