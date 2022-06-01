using UnityEngine;
public class KarakterHareket : MonoBehaviour
{
    private CharacterController kontrol;
    private float Hız = 3f;
    private Vector3 HareketVektor;
    private float DikeyHız = 0;
    private float YerÇekimi;
    private bool İsDead = false;
    public AudioSource ses;
    void Start()
    {
        kontrol = GetComponent<CharacterController>();
        if (kontrol.isGrounded)
        {
            DikeyHız = 0.5f;
        }
        else
        {
            DikeyHız -= YerÇekimi * Time.deltaTime;
        }
    }
    void Update()
    {
        if (İsDead)
        {
            return;
        }
        HareketVektor = Vector3.zero;
        HareketVektor.x = Input.GetAxisRaw("Horizontal") * Hız;

        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x > Screen.width / 2)
                HareketVektor.x = Hız;
            else
                HareketVektor.x = -Hız;
        }
        HareketVektor.y = DikeyHız;
        HareketVektor.z = Hız;
        _ = kontrol.Move(HareketVektor * Hız * Time.deltaTime);
    }
    public void GeçerliHiz(float modifier)

    {
        Hız = Hız++ + (Time.deltaTime * modifier);

    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.point.z>transform.position.z+kontrol.radius&& hit.gameObject.tag =="enemy")
        {
            Ölüm();
            ses.Stop();
        }
    }
    private void Ölüm()
    {
        İsDead = true;
        GetComponent<Skor>().OnDeath();
    }
}
