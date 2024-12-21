namespace Domain.Entities;

public abstract class CommonAbstract
{
    public string? CreatedBy { get; set; } // Người tạo
    public DateTime CreatedDate => DateTime.Now;
    public string? ModifiedBy { get; set; } // Người chỉnh sửa
    public DateTime? ModifiedDate { get; set; } // Ngày chỉnh sửa
}