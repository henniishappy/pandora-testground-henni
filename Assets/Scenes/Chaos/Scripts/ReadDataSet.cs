using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;

public class ReadDataSet : MonoBehaviour
{
    private DataSet readDS;
    private DataTable fastQTable;
    private DataTable fast5Table;

    //sources:
    // https://docs.microsoft.com/de-de/dotnet/api/system.data.dataset?view=net-6.0 (06.07.2022)
    // https://docs.microsoft.com/de-de/dotnet/framework/data/adonet/dataset-datatable-dataview/creating-a-dataset (06.07.2022)
    void Start()
    {
        // initialize data set
        readDS = new DataSet("ReadSet");

        //initialize and set up tables
        createFastQTable();
        createFast5Table();
    }

    public DataTable getFastQData()
    {
        return fastQTable;
    }

    public DataTable getFast5Data()
    {
        return fast5Table;
    }

    // https://docs.microsoft.com/de-de/dotnet/framework/data/adonet/dataset-datatable-dataview/adding-a-datatable-to-a-dataset (06.07.2022)
    private void createFastQTable()
    {
        //initialize table
        fastQTable = readDS.Tables.Add("FastQ");

        //add autoincrementing ID and set as primary key
        DataColumn readID = fastQTable.Columns.Add("ID", typeof(int));
        //https://www.aspsnippets.com/Articles/Add-Insert-AutoIncrement-Auto-Number-column-to-DataTable-in-C-and-VBNet.aspx (11.07.2022)
        readID.AutoIncrement = true;
        readID.AutoIncrementSeed = 1;
        readID.AutoIncrementStep = 1;
        fastQTable.PrimaryKey = new DataColumn[] { readID };

        //add data columns
        fastQTable.Columns.Add("Bases", typeof(string));
        fastQTable.Columns.Add("Quality", typeof(string));
    }

    // https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/dataset-datatable-dataview/defining-primary-keys (06.07.2022)
    private void createFast5Table()
    {
        //initialize table
        fast5Table = readDS.Tables.Add("Fast5");

        //set primary key
        DataColumn[] keys = new DataColumn[2];
        keys[0] = fast5Table.Columns.Add("ReadID", typeof(int));
        keys[1] = fast5Table.Columns.Add("Position", typeof(int));
        fast5Table.PrimaryKey = keys;

        //add data column
        fast5Table.Columns.Add("Signal", typeof(int));
    }

    

}
