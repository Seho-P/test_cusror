# MCP 테스트

##MCP란 (Model Context Protocol)

Model Context Protocol(MCP)는 LLM 애플리케이션과 외부 데이터 소스 및 도구 간의 원활한 연동을 가능하게 해주는 오픈 프로토콜입니다. 

AI 기반 IDE를 만들거나, 채팅 인터페이스를 개선하거나, 맞춤형 AI 워크플로우를 구축하든 MCP는 LLM이 필요한 컨텍스트에 표준화된 방식으로 접근할 수 있도록 도와줍니다.

LLM이 내가 사용하는 어플리케이션을 하나의 도구로 활용할 수 있게 만들어주는 방법이라고 볼 수 있습니다.


## 사용방법

오픈소스로 존재하는 Unity 버전의 MCP를 이용하여 AI챗봇과 결합하여 이용해줍니다

저는 Cursor를 이용했습니다. 

사용을 위해서는 파이썬 3.1.2 버전 이상과 uv 패키지 매니저(pip install uv)을 필요로 합니다.


<img width="361" height="180" alt="image" src="https://github.com/user-attachments/assets/21e571da-54f1-446d-90a0-d33ba1fe44d0" />

https://github.com/CoplayDev/unity-mcp?path=/UnityMcpBridge

package manger에서 위의 링크를 넣어서 설치해줍니다.

그러면 아래그림 처럼 MCP UNITY가 나타납니다.

<img width="292" height="193" alt="image" src="https://github.com/user-attachments/assets/043f3463-9a21-4de9-b0c5-692d2b2483d5" />

<img width="698" height="471" alt="image" src="https://github.com/user-attachments/assets/69767724-a846-4ee3-85e3-a5493ef2327f" />

Auto-setup을 누르면 자동으로 필요한 파일이 설치되고 mcp서버가 실행됩니다

아래에서는 cursor를 고르고 auto-configure를 눌러주면 커서와 유니티가 연동되며 설정이 완료됩니다.

기존에는 빨간불이 존재하나 완료되면 제 화면 처럼 모두 초록불로 될겁니다.





## 실제이용

<img width="299" height="464" alt="image" src="https://github.com/user-attachments/assets/c3484ef0-c9f7-4bfa-a175-5b2cbaf62f88" />

실제로 프로그래밍 도중 이용해봤습니다

저의 씬을 읽어서 파악한후 순서에 맞게 진행하는 모습입니다. 

<img width="455" height="301" alt="image" src="https://github.com/user-attachments/assets/a49961a6-9dc7-41aa-a11f-ce5eb335910a" />

이런 식으로 한줄씩 추가하거나

괜찮다면 전체를 전부 추가할 수도 있습니다.

<img width="1326" height="700" alt="image" src="https://github.com/user-attachments/assets/5771bf2b-820b-4e63-8051-650acd2d14d0" />

짧은시간만에 60줄 가까이 되는 코드를 만들어 내는 모습을 보여줍니다.

## 간단한 평가

장점: 처음 구성할 때 전체적인 틀을 짧은 시간에 만들어 줘서 기반을 다지기 좋음


단점: MCP를 연동해서 직접 씬의 게임오브젝트까지 조작하니 시간이 상당히 걸림, 또 사소한 곳에서 오류가 자주 발생함(ex. 색을 입히는데 0~255 범위인데 0~1범위로 자꾸 하려고해 자꾸 흰색으로 초기화됨)


종합 : 적절히 사용한다면 좋을 것 같지만 개인적으로는 코드부분만 AI를 이용하는게 좋을 것 같다. 초보자의 경우에는 씬 까지 만들어 주는게 매우 효과적이지만 조금만 할 줄 안다면 MCP까지는 필요 없는 것 같다.

## 간단한 시연

간단히 만들어본 움직이는 플레이어와 추적하는 적입니다.

![test_cusror - SampleScene - Windows, Mac, Linux - Unity 6 0 (6000 0 57f1) _DX11_ 2025-10-15 22-02-28](https://github.com/user-attachments/assets/dcfb311c-4cbc-4338-b04b-7739d6d1f58f)




