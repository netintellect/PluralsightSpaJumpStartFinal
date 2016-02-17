using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telerik.Windows.Examples.HeatMap.CollegesAndUniversities
{
    public class MainViewModel : DataSourceViewModelBase
    {
        public IEnumerable<Institution> data;
        public IEnumerable<Institution> Data
        {
            get { return this.data; }
            set
            {
                if (this.data != value)
                {
                    this.data = value;
                    this.OnPropertyChanged("Data");
                }
            }
        }

        public MainViewModel()
        {
            this.GetData("Universities.csv");
        }

        protected override void GetDataCompleted(System.Collections.IEnumerable data)
        {
            IEnumerable<Institution> institutionInfos = data as IEnumerable<Institution>;
            this.Data = new List<Institution>(institutionInfos);
        }

        protected override System.Collections.IEnumerable ParseData(System.IO.TextReader dataReader)
        {
            string line;
            List<Institution> institutionInfos = new List<Institution>();

            while ((line = dataReader.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                
                string[] data = line.Split(',');

                var newInstitution = new Institution();
                newInstitution.Name = data[0];
                
                int intVal;
                
                if(int.TryParse(data[1], out intVal))
                    newInstitution.SmartRank  = intVal;

                if(int.TryParse(data[2], out intVal))
                    newInstitution.AcceptanceRate  = intVal;

                if(int.TryParse(data[3], out intVal))
                    newInstitution.TotalEnrolledStudents  = intVal;

                if(int.TryParse(data[4], out intVal))
                    newInstitution.AverageSATMathScore  = intVal;

                if(int.TryParse(data[5], out intVal))
                    newInstitution.AverageSATVerbalScore  = intVal;

                if(int.TryParse(data[6], out intVal))
                    newInstitution.AverageSATCompositeScore  = intVal;

                if(int.TryParse(data[7], out intVal))
                    newInstitution.FulltimeRetentionRate  = intVal;

                if(int.TryParse(data[8], out intVal))
                    newInstitution.InStateTuition  = intVal;

                if(int.TryParse(data[9], out intVal))
                    newInstitution.OutOfStateTuition  = intVal;
                
                if(int.TryParse(data[10], out intVal))
                    newInstitution.Endowment  = intVal;
                
                institutionInfos.Add(newInstitution);
            }

            return institutionInfos;
        }
    }
}
