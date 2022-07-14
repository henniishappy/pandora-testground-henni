using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.Linq;

public class ReadManager : MonoBehaviour
{
  
    private DataTable fastQData;
    private DataTable fast5Data;

    // Start is called before the first frame update
    void Start()
    {
        //connect to instance of ReadDataSet
        ReadDataSet readDB = FindObjectOfType<ReadDataSet>();
        fastQData = readDB.getFastQData();
        fast5Data = readDB.getFast5Data();
    }


    /// <summary>
    /// Count number of reads in a specific table
    /// </summary>
    /// <param name="table">name of table the reads to be counted are stored in</param>
    /// <returns>number of reads in specified table</returns>
    public int getNumberOfReads(string table)
    {
        switch (table)
        {
            case "fastQ":
                return fastQData.Rows.Count;
            case "fast5":
                // source: https://stackoverflow.com/questions/17466253/select-distinct-values-from-a-large-datatable-column (06.07.2022)
                DataView readIdView = new DataView(fast5Data);
                DataTable distinctIds = readIdView.ToTable(true, "ReadID");
                return distinctIds.Rows.Count;
            default:
                return 0;
        }
    }

    /// <summary>
    /// Select base sequence of read with specific id
    /// </summary>
    /// <param name="id">id of the requested read</param>
    /// <returns>the read values as string</returns>
    public string getRead(int id)
    {
        // https://stackoverflow.com/questions/13816490/get-cell-value-from-a-datatable-in-c-sharp#13816531 (06.07.2022)
        return fastQData.Rows[id].Field<string>("Bases");
    }

    /// <summary>
    /// Select quality of read with specific id
    /// </summary>
    /// <param name="id">id of the requested read</param>
    /// <returns>quality values as string</returns>
    public string getQuality(int id)
    {
        return fastQData.Rows[id].Field<string>("Quality");
    }

    /// <summary>
    /// Select all signals of a specific read
    /// </summary>
    /// <param name="id">id of the requested read</param>
    /// <returns>all signals of the requested read as an inetger array</returns>
    public int[] getSignal(int id)
    {
        // https://www.codeproject.com/Questions/1201915/How-to-get-the-datarow-value-from-datatable-in-Csh (06.07.2022)
        DataRow[] signals = fast5Data.Select("ReadID = " + id);

        // https://stackoverflow.com/questions/32959468/example-of-array-map-in-c (11.07.2022)
        return signals.Select(row => row.Field<int>("Signal")).ToArray();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sequence"></param>
    /// <param name="quality"></param>
    public void saveFastQRead(string sequence, string quality)
    {
        fastQData.Rows.Add(null, sequence, quality);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="read"></param>
    public void saveFast5Read(int[] read)
    {
        var id = getNumberOfReads("fast5") + 1;
        var pos = 1;

        foreach(int signal in read)
        {
            fast5Data.Rows.Add(id, pos, signal);
            pos++;
        }
    }
}
