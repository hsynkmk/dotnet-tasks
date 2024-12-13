namespace PrinciplesOfSOLID
{
    #region Without ISP
    // A very large interface
    public interface IEmployee
    {
        void Work();
        void Manage();
        void ConductTraining();
        void WriteCode();
        void Design();
    }

    // Classes that inherits the interface forced to implement all methods
    public class WrongDeveloper : IEmployee
    {
        public void Work()
        {
            Console.WriteLine("Developer is working...");
        }

        public void Manage()
        {
            throw new NotImplementedException();
        }

        public void ConductTraining()
        {
            throw new NotImplementedException();
        }

        public void WriteCode()
        {
            Console.WriteLine("Developer is writing code...");
        }

        public void Design()
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    
    #region With ISP
    // Segregated interfaces
    public interface IWorker
    {
        void Work();
    }

    public interface IManager
    {
        void Manage();
    }

    public interface ITrainer
    {
        void ConductTraining();
    }

    public interface IDeveloper
    {
        void WriteCode();
    }

    public interface IDesigner
    {
        void Design();
    }

    // Now Developer class can implement only relevant interfaces
    public class Developer : IWorker, IDeveloper
    {
        public void Work()
        {
            Console.WriteLine("Developer is working...");
        }

        public void WriteCode()
        {
            Console.WriteLine("Developer is writing code...");
        }
    }

    #endregion
}
