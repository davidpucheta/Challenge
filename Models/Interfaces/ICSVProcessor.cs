namespace Models.Interfaces;

public interface ICSVProcessor
{
    void ImportCSVFile(string filePath);
}