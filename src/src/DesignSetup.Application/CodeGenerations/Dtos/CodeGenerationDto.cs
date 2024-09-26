namespace DesignSetup.Application.CodeGenerations.Dtos
{
    public class CodeGenerationDto
    {
        public string tableName { get; set; }

        public string describe { get; set; }
        public string schemasName { get; set; }

        public DateTime? create_date { get; set; }
        public DateTime? modify_date { get; set; }
    }
}
