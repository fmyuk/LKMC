using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour {

    public Transform target;
    public float speed;
    public bool reverse;
    public bool drowLine;

    private float startDistance;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        startDistance = Vector3.Distance(this.transform.position, target.position);

        rigidbody = gameObject.GetComponent<Rigidbody>();

        if (this.transform.position.z - target.position.z == 0)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 0.01f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        float distance = Mathf.Sqrt(Mathf.Pow(this.transform.position.x - target.position.x, 2) + Mathf.Pow(this.transform.position.z - target.position.z, 2));

        float p = this.transform.position.x - target.position.x;
        float q = this.transform.position.z - target.position.z;

        float offset = reverse
      ? (this.transform.position.z > target.position.z) ? -1 : 1
      : (this.transform.position.z > target.position.z) ? 1 : -1;

        float x = p + offset;
        // px + qy = distance^2
        float z = (Mathf.Pow(distance, 2) - (p * x)) / q;

        Vector3 tangentVector = (new Vector3(target.position.x + x, this.transform.position.y, target.position.z + z) - this.transform.position).normalized;

        Debug.DrawLine(this.transform.position, this.transform.position + tangentVector * 10);

        //// 円の接線ベクトルを描画
        if (this.drowLine)
        {
            Debug.DrawLine(this.transform.position, this.transform.position + tangentVector * 10);
        }

        //// 接線ベクトル等速で移動
        this.rigidbody.velocity = tangentVector * speed * Time.fixedDeltaTime;

        // 進行方向へ向かせる
        this.transform.LookAt(this.transform.position + tangentVector);

        // 以下は座標の制限、x、z共に最初の距離以上離れないようにする。

        if (this.transform.position.x > this.target.transform.position.x + startDistance)
        {
            this.transform.position = new Vector3(this.target.transform.position.x + startDistance, this.transform.position.y, this.transform.position.z);
        }

        if (this.transform.position.x < this.target.transform.position.x - startDistance)
        {
            this.transform.position = new Vector3(this.target.transform.position.x - startDistance, this.transform.position.y, this.transform.position.z);
        }

        if (this.transform.position.z > this.target.transform.position.z + startDistance)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.target.position.z + startDistance);
        }

        if (this.transform.position.z < this.target.transform.position.z - startDistance)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.target.position.z - startDistance);
        }
    }
}
