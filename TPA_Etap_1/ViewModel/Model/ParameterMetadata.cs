
namespace TPA.Reflection.Model
{
  public class ParameterMetadata
  {

    public ParameterMetadata(string name, TypeMetadata typeMetadata)
    {
      this.m_Name = name;
      this.m_TypeMetadata = typeMetadata;
    }
    
    //private vars
    public string m_Name { get; set; }
    public TypeMetadata m_TypeMetadata { get; set; }

    }
}