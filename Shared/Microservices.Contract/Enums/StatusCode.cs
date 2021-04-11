namespace Microservices.Contract.Enums
{
    public enum StatusCode
    {
        Ok = 200, //Dönüş Body si olan başarılı kayıt
        OkNoContent = 204, //Dönüş Body si olmayan başarılı kayıt
        NotFound = 404, // Kayıt bulunamadığında dönüş
        Failed = 400, // İşlem başarısız olduğunda
    }
}
