using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceChange : MonoBehaviour
{

    // 화면 중앙의 점
    // 바닥의 발판을 바라보면 게이지가 차며 장소가 변경됨
    public Image imagePointer;

    // 게이지가 차는 정도
    private float pointerCharge;

    // 바라보는 발판을 확인하기 위해 저장하는 임시변수
    private RaycastHit hit;

    // 발판이 가지는 장소 정보
    private Place place;

    // 게임 시작 시 자동으로 실행되는 함수
    void Start()
    {
        Reset();
    }

    // 매 프레임 자동으로 실행되는 함수
    void Update()
    {
        RayCheck();
    }

    // 화면 중앙에서 Ray를 쏴서 부딪히는 것이 있는지 판단 ( Ray : 반직선 )
    // 부딪힌것이 발판인 경우(발판엔 Place.cs가 포함되어 있음) Place내의 placeMaterial 값을 가져옴
    void RayCheck()
    {
        if(Physics.Raycast(this.transform.position, this.transform.forward, out hit, 5f))
        {
            // 부딪힌 것에서 Place.cs를 찾음
            place = hit.collider.GetComponent<Place>();

            // 부딪힌 것이 Place.cs를 포함하고 있는 경우 (null은 없는것)
            if(place != null)
            {
                //게이지를 증가시킴
                pointerCharge += Time.deltaTime;

                // pointerCharge 값에 따라 게이지 ui를 보이게 함
                // pointerCharge가 0이면 안보임, 1이면 완전히 보임
                imagePointer.fillAmount = pointerCharge;

                //게이지가 거의 찼을 경우 실행
                if(imagePointer.fillAmount > 0.9f)
                {
                    ChangePlace(place.placeMaterial);

                    Reset();
                }
            }
            else
            {
                Reset();
            }
        }
        else
        {
            Reset();
        }
    }

    // 현재 주변 환경은 skybox라는 것으로 정의되어 있음
    // skybox를 변경하면 주변 환경이 다르게 보이게 됨
    void ChangePlace(Material mat)
    {
        RenderSettings.skybox = mat;
    }

    //게이지에 대한 값 초기화
    void Reset()
    {
        pointerCharge = 0;
        imagePointer.fillAmount = 0;
    }
}
