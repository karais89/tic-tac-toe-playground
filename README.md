# pg/tic-tac-toe-playground

- https://learn.unity.com/tutorial/creating-a-tic-tac-toe-game-using-only-ui-components
- 프로젝트 자체는 jetbrains space를 사용하여 관리 (보드, 저장소 등)
- IDE는 jetbrains Rider 사용
- Unity 2020.3.11f1

## 1.Introduction and setting-up the project

소개

이 과제에서는 내장된 Unity UI 도구 세트와 두 개의 기본 스크립트만 사용하여 Tic-Tac-Toe 게임(Noughts and Crosses라고도 함)을 만들 것입니다.

그림

이 강의에서 게임을 만드는 접근 방식은 두 가지 중요한 사실을 보여주어야 합니다.

첫 번째는 Unity UI 도구 세트의 다양성입니다. Unity의 UI 툴셋은 매우 강력하며 주어진 프로젝트에서 많은 작업을 수행하는 데 사용할 수 있습니다.
이러한 작업 중 많은 부분이 처음에는 UI와 관련이 없어 보일 수 있지만 UI 도구 집합은 우리를 훌륭하고 예상치 못한 솔루션으로 바꿀 수 있습니다.
이 프로젝트에서는 사용자 지정 그래픽, 스프라이트 시트 또는 복잡한 상호 작용을 사용하지 않고 Unity의 UI와 두 개의 간단한 스크립트를 사용하여 이 게임을 "즉시 사용 가능한" 방식으로 완전히 만들 수 있는 방법을 보여드리고자 합니다.

이에 더하여, 우리는 프로젝트를 관리 가능한 부분으로 쪼개어 살펴보고자 합니다. 
한 번에 하나의 문제에 접근하고 해결합니다. 우리는 완성된 제품으로 바로 뛰어가기 보다는 어떤 게임 프로젝트에서나 할 수 있는 디자인 및 프로토타이핑 단계를 따르고 미리 만들어진 부품에서 완성된 게임을 조립하는 방법만 설명합니다. 
이러한 디자인 및 프로토타이핑 단계에는 코드를 리팩토링하고 이 단원을 진행하면서 프로젝트 범위를 조정하는 작업이 포함됩니다.

단순히 완성된 최종 프로젝트를 보여주는 것보다 이 접근 방식이 이 프로젝트에서 선택한 근본적인 이유를 이해하는 데 도움이 될 뿐만 아니라 게임을 만드는 데 필요한 많은 작은 단계를 이해하는 데 도움이 되기를 바랍니다.

작은 프로젝트라도 범위에 겁을 먹기 쉽습니다. 
"어디부터 시작할까요?" "What now?"라는 일반적인 질문이 이어집니다. 
이 프로젝트를 수행한 후 모든 사람들이 더 작고 관리하기 쉬운 조각으로 나누어 더 큰 프로젝트를 시작할 수 있기를 바랍니다.

### 게임의 범위

게임 플레이는 간단합니다.

9개의 타일 또는 그리드 공간으로 분할된 간단한 정사각형 게임 보드가 있습니다. 
플레이어가 그리드 공간 중 하나를 클릭하면 "X" 또는 "O"가 할당됩니다. 
한 플레이어가 연속으로 3개의 그리드 공간을 주장하거나 남은 이동이 없으면 게임이 종료됩니다. 
게임을 완성하기 위해 약간의 광택이 필요합니다. 게임이 시작되면 첫 번째 플레이어가 "X" 또는 "O"를 플레이할지 여부를 선택할 때까지 보드가 활성화되지 않습니다. 
누구의 차례인지 패널에 표시됩니다. 게임이 끝나면 배너에 승자가 표시되거나 아무도 이기지 않으면 무승부가 표시됩니다. 
게임이 끝나면 다시 시작 버튼이 표시되며 클릭하면 게임이 시작 상태로 돌아갑니다.

게임에는 몇 가지 기본 요소가 필요합니다.
- 전체 게임의 배경을 제공하는 배경입니다.
- 게임 보드가 될 요소입니다.
- 게임 보드를 짝수 그리드의 9개 영역으로 나누는 요소 또는 요소 집합입니다.
- "X" 또는 "O"를 할당할 수 있지만 이러한 값을 할당하면 현재 플레이어나 상대방 플레이어가 변경할 수 없는 9개의 타일이 유지됩니다.
- 플레이어가 턴을 할 때 진영을 바꾸는 논리.
- 아무도 이기지 못하는 무승부를 허용하는 "승리" 조건을 확인하는 논리
- 게임이 종료되면 승자가 누구인지 표시하는 패널입니다.

광택을 위해 프로젝트가 끝날 무렵 다른 유용한 요소가 있을 수 있습니다
- 시작 플레이어의 편을 선택하는 방법, "X" 또는 "O".
- 누구의 차례인지를 나타내는 지표입니다.
- 다시 시작 버튼입니다.
- 매우 기본적인 지침.

마지막으로, 이 연습의 일부로 Unity의 내장 UI 도구 세트에서 제공하는 요소만 사용할 것입니다.

### Setting up the Project

Unity를 열고 새 2D 프로젝트를 생성하여 시작합니다.
- 프로젝트의 이름을 "tictactoe"(또는 다른 이름)를 지정하십시오.
- 위치를 선택하여 프로젝트를 저장합니다
- "2D"를 선택하여 기본 프로젝트 유형을 2D로 설정합니다.
- "프로젝트 생성" 버튼을 클릭하여 프로젝트를 생성합니다.

그림 설명

프로젝트 유형 및 2D와 3D 프로젝트의 차이점에 대한 자세한 내용은 Unity 매뉴얼의 2D 및 3D 프로젝트에 대한 세부 정보를 참조하십시오.

Unity 에디터에서 프로젝트가 열리면
- 프로젝트 창에서 "Scenes"라는 폴더를 만듭니다.
- Scenes 폴더의 기본 장면을 "Main"으로 저장합니다.

그림 설명

새 프로젝트 시작, 폴더 생성 또는 장면 저장에 대한 자세한 내용은 Unity 매뉴얼의 시작하기 페이지에서 시작하여 새 프로젝트 생성에 대한 강의를 참조하십시오.

다음 강의에서는 상징적인 Tic-Tac-Toe 보드를 만들 것입니다.

## 2.Creating the game board

배경을 만들고 게임 보드를 만든 다음 그리드 오버레이를 사용하여 게임 보드를 9개의 균일한 공간으로 분할해야 합니다.

이를 위해 내장 UI 도구 세트를 사용할 것이므로 가장 먼저 만들어야 할 것은 UI 패널입니다.
- 만들기 > UI > 패널을 사용하여 장면에 새 UI 패널 요소를 만듭니다.

그림 설명

그러면 장면에 새 UI 패널, 상위 캔버스 및 EventSystem이 생성됩니다.

그림 설명

캔버스 및 이벤트 시스템은 UI 도구 세트에 필요합니다. 게임에 맞게 캔버스 크기를 조정합니다.
- 캔버스 게임오브젝트를 선택합니다.
- Inspector에서 Canvas Scaler를 찾습니다.
- 배율을 0.8로 설정

UI 패널, 상위 캔버스 및 이벤트 시스템을 포함한 UI 도구 세트에 대한 자세한 내용은 UI 도구 세트에 대한 강의를 참조하세요

장면 뷰가 활성화된 상태에서 패널 요소에서 프레임이 선택되었습니다. 
이 Panel 요소가 부모 Canvas를 채우도록 늘어나서 차례로 Game 화면을 채우는 것을 볼 수 있습니다. 
앵커를 보면 패널이 늘어남을 알 수 있습니다. 아래 이미지 모서리에 있는 4개의 작은 삼각형입니다.

앵커 및 스트레칭에 대한 자세한 내용은 Unity에서 UI 작업에 대한 강의를 참조하세요.

그림 설명

이 패널은 배경이 될 것이며 검정색으로 설정할 것입니다. 
배경이 항상 화면을 채우길 원하므로 늘이는 동작을 유지합니다. 
그러나 색상과 불투명도를 설정해야 합니다. 
이 특정 게임 오브젝트를 정의하는 다양한 구성 요소의 속성을 변경하여 이를 수행할 수 있습니다.
- 패널 게임 오브젝트를 선택합니다.

그림 설명

- 패널 게임 오브젝트 선택
    - 이름을 Background로 변경
    - 이미지 색상을 검정색으로 변경

그림 설명

이제 전체 Game View를 덮는 단색 검정색 배경이 있어야 하며 Game View 창의 크기에 관계없이 채우기 위해 확장됩니다.

다음으로 우리는 게임 보드를 만들 것입니다.

이를 위해 다른 패널을 만들고 해당 속성도 설정합니다. 
게임 보드 패널이 부모 캔버스와 함께 늘어나는 것을 원하지 않습니다. 
우리는 Panel이 부모 Canvas 안에 단독으로 있기를 원합니다. 
또한 패널의 색상과 불투명도를 설정하여 적절한 게임 보드처럼 보이도록 합니다.

게임 보드를 설정하려면:
- 만들기 > UI > 패널을 사용하여 장면에 새 UI 패널 요소를 만듭니다.

이 패널은 캔버스를 채우기 위해 다시 늘어납니다.
- 새로운 패널 선택
    - 이름을 Board로 변경
    - ... 앵커 및 사전 설정 메뉴 선택:
        그림 설명 
      
앵커 및 사전 설정 패널이 열립니다.
- 패널의 앵커 및 사전 설정 메뉴가 열린 상태에서
    - shift와 alt 키를 누른 상태에서
    - middle/center 선택
    
그림 설명

이렇게 하면 앵커, 피벗 및 위치가 상위 캔버스의 가운데와 가운데로 변경되어야 합니다. 
앵커를 정의하는 4개의 작은 삼각형을 보면 이를 알 수 있습니다. 
Background를 사용하면 상위 Canvas의 네 모서리에 배치되어 있음을 알 수 있습니다(위 이미지 참조). 
Board를 사용하면 앵커가 부모 Canvas의 중간에 위치하는 것을 볼 수 있습니다.

그림 설명

Shift 키를 누르고 있으면 피벗 위치가 설정되고 Alt 키를 누르고 있으면 UI 요소의 위치가 설정되므로 두 키를 모두 누르고 있으면 앵커링을 변경할 뿐만 아니라 피벗과 위치도 재설정되므로 패널이 부모 Canvas의 중앙과 중앙에 있는 것이 보장됩니다.

이것을 보드처럼 보이게 하려면 패널의 크기와 색상에 영향을 주어야 합니다.

- Board 선택
- Baord 선택한 상태에서
    - ... RectTransform의 Width 속성을 512로 설정합니다.
    - ... RectTransform의 height 속성을 512로 설정합니다.
    - ... Image 구성 요소의 Color 속성을 매우 진한 파란색(33, 44, 55, 255)으로 설정합니다.

이것은 파란색 힌트가 있는 짙은 회색이며 불투명도가 100%입니다.
이 색상을 선택했지만 색상 피커를 닫기 전에 색상 피커의 왼쪽 하단에 있는 사전 설정 버튼을 클릭하여 이 색상을 사전 설정으로 저장합니다. 
이 색상을 재사용할 것이므로 매번 다시 만드는 것보다 색상을 사전 설정으로 저장하는 것이 더 쉽습니다.

그림 설명

이제 게임 보기에서 검은색 배경에 보드가 표시되어야 합니다

그림 설명

다음 단계는 게임 보드를 9칸의 그리드로 나누는 것입니다. 이를 위해 UI 패널 요소도 사용하지만 패널의 매우 얇은 버전을 만들 것입니다.

이 시점에서 UI 패널의 구성에 주목할 가치가 있습니다.

UI 패널은 미리 만들어진 UI 요소입니다. 
RectTransform 구성 요소, Canvas Renderer 구성 요소 및 Image 구성 요소로 구성됩니다. 
RectTransform은 장면에서 UI 요소가 있는 위치를 정의하고, Image 구성 요소는 그려야 하는 그래픽 요소에 대한 세부 정보를 보유하며, 이러한 요소는 RectTransform에 의해 정의된 장면의 위치에서 Canvas 렌더러에 의해 그려집니다.

UI 이미지 요소를 임시로 생성하는 경우 UI 이미지가 UI 패널의 것과 동일한 경우 기본 구성을 볼 수 있습니다. 
둘 다 RectTransform, Canvas Renderer 및 Image 구성 요소가 있습니다. 
UI 패널과 UI 이미지의 차이점은 속성의 세부 사항입니다. 
각각은 RectTransform의 Anchors, Pivots 및 Size 속성과 이미지의 소스 이미지에 대해 서로 다른 기본값을 갖습니다. 
UI 패널은 늘어나지만 UI 이미지는 그렇지 않습니다. 
UI 이미지의 크기는 (100, 100)으로 정의되어 있습니다. 
UI 패널에는 사전 설정된 소스 이미지가 있고 UI 이미지에는 없습니다. 
UI 패널은 신축성 있는 패널로 사전 설정되어 있는 반면 UI 이미지는 정적 그래픽 이미지에 대해 사전 설정되어 있습니다.

이것이 우리에게 의미하는 바는 우리가 원하는 목적에 적합하다고 생각되는 대로 둘 중 하나를 사용할 수 있다는 것입니다. 
UI 패널은 반드시 다른 항목을 담는 용도로만 사용되는 것은 아닙니다. 
단순히 그래픽 요소로 사용할 수 있습니다. 
다음 단계에서는 UI Image 요소를 사용할 수 있지만 최소한 Image 구성 요소의 Source Image 속성에 Background 스프라이트를 추가해야 하므로 이 경우 수업 중에 UI 패널을 사용합니다.

임시 UI 이미지가 생성된 경우 삭제하십시오.

그리드"를 생성하려면
- 만들기 > UI > 패널을 사용하여 장면에 새 UI 패널 요소를 만듭니다.
- 패널 게임 오브젝트가 선택된 상태에서
    - 이름을 Grid로 변경
    - 앵커와 피벗을 middle/center로 변경
    - width 5로 설정
    - height 512로 설정
    - position x를 -85.33으로 설정
    - 칼라 핑크로 설정(255, 0, 102, 255)
    - 설정된 칼라는 프리셋으로 저장

위치 X 값에 대한 매직 넘버 -85.33은 어떻게 얻었습니까?
이것은 단순히 기본 수학으로 수행됩니다. 
보드는 512픽셀 x 512픽셀입니다. 
간단히 512를 3으로 나누면 170 정도의 숫자가 됩니다(이 숫자는 곧 다시 표시됩니다). 
그러나 장면이나 화면 공간에 위치를 지정할 때 세계는 원점에서 시작하고 위치 값은 한 방향으로 양수이고 다른 방향으로 음수입니다. 
게임 보드는 중앙에 0의 위치 X가 있고 각 모서리에 -256 및 256의 위치 X가 있는 화면 중앙에 있습니다. 
우리는 그리드 라인이 0에서 256까지의 1/3, 또는 256을 3으로 나눈 값이 85.33이 되기를 원합니다!

그림 설명

이제 Unity에서 사용할 수 있는 바로 가기가 있습니다. 
설정하려는 필드에 수학을 직접 입력하면 됩니다(이 경우 -256/3). 512/-2/3을 사용할 수도 있습니다.

그림 설명

이제 하나의 분할 그리드 선이 있어야 합니다.

그림 설명

나머지 그리드 선을 만들기 위해 이 요소를 복제하고 재배치합니다.
- 그리드 게임 오브젝트를 복제합니다.
- 그리드(1) 게임 오브젝트가 선택된 상태에서
    - pos x를 85.33으로 이동
    - 게임 오브젝트 복제
- 그리드(2) 게임 오브젝트가 선택된 상태에서
    - pos x를 0으로 설정
    - pos y를 85.33
    - width 512
    - height 5
    - 그리드(2) 복제
- 그리드(3) 게임 오브젝트가 선택된 상태에서
    - pos y를 -85.33

이제 클래식 게임 그리드가 있어야 합니다.

그림 설명

다음 수업에서는 게임 보드 및 그리드 공간과의 핵심 상호 작용을 설정합니다.

## 3.Interaction with the game board

기본 게임 보드가 설정되었으므로 이제 플레이어가 게임과 상호 작용할 수 있는 방법을 찾아야 합니다. 플레이어는 그리드 사각형을 클릭하고 해당 공간에 "X" 또는 "O" 값을 할당할 수 있어야 합니다.

사용자로부터 "클릭" 상호작용을 얻는 가장 좋은 방법 중 하나는 UI 버튼을 사용하는 것입니다.
UI 버튼은 클릭을 감지하고 입력에 대한 응답으로 작업 또는 일련의 작업을 수행할 수 있습니다.
편리하게도 UI 버튼에는 UI 텍스트 요소가 자식으로 첨부되어 있습니다. 
플레이어의 값을 "X" 또는 "O"로 표시하는 쉽고 편리한 방법은 플레이어의 움직임을 첨부된 UI 텍스트 요소에 텍스트 문자로 직접 추가하는 것입니다.
- 만들기 > UI > 버튼을 사용하여 장면에 UI 버튼 요소를 만듭니다.
- 버튼 게임 오브젝트가 선택된 상태에서
  - 게임 오브젝트의 이름을 "Grid Space"로 바꿉니다.
  - ... 상황에 맞는 기어 메뉴를 사용하여 RectTransform을 재설정합니다.
  - 넓이와 높이를 128로 설정합니다.
이렇게 하면 게임 보드 중앙에 버튼이 생성됩니다.

그림 설명

다음 단계는 UI Button 요소의 스타일을 설정하는 것입니다. 
Button 구성 요소의 전환 요소 색상과 자식 UI Text 요소의 색상 Text 구성 요소를 설정하여 이를 수행합니다.
- 계층에서 Grid Space 게임 오브젝트를 선택합니다.
- Grid Space 게임 오브젝트가 선택된 상태에서 Button 구성 요소에서
  - 전환: 일반 색상을 파란색(0, 204, 204, 255)으로 설정합니다.
  - 색상 선택기를 닫기 전에 이 색상을 사전 설정으로 저장하십시오.
  - 전환: 강조 색상을 밝은 파란색(128, 255, 255, 255)으로 설정합니다.
  - 이 색을 사전 설정으로 저장하십시오.
  - 전환: Pressed Color를 짙은 청록색(51, 102, 102, 255)으로 설정합니다
  - 이 색을 사전 설정으로 저장하십시오.
  - 전환: 비활성화된 색상을 진한 파란색(55, 66, 77, 255)으로 설정합니다.
  - 이 색을 사전 설정으로 저장하십시오.

이제 Button 구성 요소는 다음과 같아야 합니다.

그림 설명

계층 창에서 아래쪽 화살표를 사용하여 자식 UI 텍스트 요소를 나타내기 위해 계층 창에서 그리드 공간 게임 오브젝트를 "열기"해야 합니다. 
Text GameObject를 선택했으면 화면에 텍스트를 표시하기 위한 속성을 설정할 수 있습니다.

그림 설명

- Grid Space의 자식인 Text GameObject를 표시하고 선택합니다.
- Text GameObject를 선택한 상태에서
  - 임시로 Text 구성 요소의 Text 속성을 대문자 "X"로 설정합니다.
  - 글꼴 크기를 111로 설정합니다.
  - 사전 설정을 사용하여 색상을 분홍색(255, 0, 102, 255)으로 설정합니다.

기본 UI 버튼이 설정됩니다.

그림 설명

이제 프리팹으로 저장할 수 있습니다.
- 프로젝트 창에서 새 폴더를 만듭니다.
- 이 폴더의 이름을 "Prefabs"로 바꿉니다.
- Hierarchy Window에서 Grid Space GameObject를 선택하고 프로젝트 창의 Prefabs 폴더로 드래그하여 새 Prefab을 만듭니다.

그림 설명

프리팹, 생성 방법 및 사용 방법에 대한 자세한 내용은 여기에서 자습서를 참조하세요.

이제 Grid Space 버튼 프리팹이 생겼습니다. 
총 9개의 버튼을 위해 이 버튼을 8번 복제해야 합니다. 
이들은 그리드 형태로 게임 보드 주위에 배치됩니다.
이 단원의 뒷부분에서 승리 조건을 확인할 때 이러한 버튼을 서로 비교할 것이므로 어떤 버튼이 어떤 위치에 있는지 추적하는 것이 필수적입니다. 
버튼이 복제되면 Unity는 게임 오브젝트 이름 끝에 숫자를 추가하여 고유한 이름을 생성합니다. 
우리는 이 숫자를 사용하여 버튼과 그 순서를 추적할 것입니다.

- Hierarchy Window에서 Grid Space GameObject를 선택하고 8번 복제합니다. 

이것은 우리에게 9개의 UI 버튼을 제공해야 합니다.

그림 설명

우리는 우리의 승리 조건을 쉽게 테스트할 수 있는 방식으로 이 새로운 Button 프리팹을 게임 보드에 정기적으로 배치해야 합니다.
이 단원의 뒷부분에서 사용할 코드의 경우 버튼의 순서는 왼쪽 위에서 시작하여 왼쪽에서 오른쪽, 위에서 아래로 행이 되어야 합니다.

그림 설명

이 버튼을 제자리로 옮기는 두 가지 쉬운 방법이 있습니다. 
하나는 값을 UI 버튼의 RectTransform에 직접 설정하는 것입니다. 
다른 하나는 장면 보기에서 버튼을 드래그하고 배치 및 스냅 기능을 사용하여 버튼을 정렬하는 것입니다.

512 x 512 픽셀이고 3개의 동일한 세그먼트로 분할된 게임 보드의 경우 512/3이 170.66이므로 균일하게 배치되기 위해 170픽셀의 일부 형태를 사용하여 위치에 버튼을 배치해야 합니다. 
이 단원에서는 소수 값을 무시합니다.

예를 들어 버튼의 RectTransform을 직접 사용하여 버튼의 위치를 설정하는 방법을 표시하려면:
- Grid Space 게임오브젝트 선택
- Grid Space 게임오브젝트를 선택한 상테에서
  - x 값을 -170
  - y 값을 170
  
장면 보기에서 정렬 도구와 이 도구가 RectTransform 값을 사용하여 요소를 조작하는 경우에도 장면에서 UI 요소의 현재 오프셋을 나타내는 방법을 확인합니다.

그림 설명

장면 보기에서 UI 요소를 이동하고 정렬하는 예:
- Grid Space (1) 히어라이키 창에서 선택

그림 설명

그러면 장면 보기에서 Grid Space (1) 게임 오브젝트가 선택됩니다.

그림 설명

- Grid Space (1) 게임오브젝트를 선택한 상테에서
  - Grid Space (1) GameObject를 Scene View에서 위로 드래그하고 Grid Space GameObject와 정렬해 봅니다.

정렬 도구가 그리드 공간 게임 오브젝트와 나머지 그리드 공간(n) 게임 오브젝트 모두에 스냅될 뿐만 아니라 오프셋 값과 정렬 기즈모를 근처 UI 요소에 표시하는 방법에 유의하십시오.

이제 각 버튼을 순서대로 선택하여 다음 다이어그램에 따라 그리드 공간당 하나의 버튼이 있는 게임 보드를 배치합니다.

그림 설명

정렬이 확실하지 않은 경우 정렬 도구 또는 버튼의 RectTransform을 사용하고 위치 X 및 위치 Y가 -170, 0 또는 170에 있는지 확인합니다.

그림 설명

이제 모든 버튼이 배치되었으므로 버튼에 "X"가 필요하지 않습니다. 이것은 단순히 Text 속성과 부모 UI 버튼의 관계가 무엇인지 알도록 돕기 위한 것입니다.

- 프로젝트 창에서 Grid Space 프리팹의 Text GameObject 자식을 선택합니다.
- 자식 텍스트 프리팹을 선택한 상태에서
  - ... 텍스트 구성 요소의 Text 속성에서 "X"를 삭제하고 비워둡니다.

최종 게임 보드는 다음과 같아야 합니다.

그림 설명

다음 레슨에서는 이후 레슨에서 구축할 기초 게임 플레이 기능을 설정할 것입니다

## 4.Foundation game play

버튼이 있지만 현재 실제로는 아무 것도 하지 않습니다.

이제 플레이어가 버튼 중 하나를 클릭할 때 발생하는 기능을 설정해야 합니다.

일을 단순하게 유지하기 위해 플레이어가 버튼을 클릭할 때 격자 공간에 "X"를 할당한 다음 더 이상 변경되지 않도록 해당 버튼을 "잠금"으로 시작하겠습니다.

이렇게 하려면 버튼 프리팹에 연결된 새 스크립트가 필요합니다
- 프로젝트 창에서 "Scripts"라는 새 폴더를 만듭니다.
- 프로젝트 창에서 "Grid Space" 프리팹을 선택합니다.
- "Grid Space" 프리팹이 선택된 상태에서
  - "GridSpace"라는 새 스크립트를 만들고 추가합니다.
- Scripts 폴더에 GridSpace 스크립트를 보관합니다.

그림 설명

- 편집을 위해 GridSpace 스크립트를 엽니다.

이 스크립트에서 로컬 Button 구성 요소와 자식 GameObject의 연결된 Text 구성 요소를 조작할 수 있으려면 먼저 Unity의 UI 도구 세트를 사용할 수 있는 적절한 네임스페이스가 필요하고 그런 다음 Button 구성 요소에 대한 참조가 필요합니다.
관련 Text 구성 요소를 사용하여 해당 속성을 설정합니다. 
우리는 또한 현재 측면의 값을 유지해야 합니다. 현재 측면은 단순히 "X"입니다.
- 스크립트 상단에 UI 네임스페이스를 추가합니다.

```cs
using UnityEngine.UI;
```

네임스페이스에 대한 자세한 내용은 여기에서 자습서를 참조하세요.
- GridSpace 클래스에서 모든 샘플 코드를 제거합니다.
- "button"이라는 로컬 Button 구성 요소에 대한 공용 변수를 만듭니다.
- "buttonText"라는 Button의 연결된 Text 구성 요소에 대한 공용 변수를 만듭니다
- "playerSide"라는 "X"에 대한 공개 문자열 변수를 만듭니다.

```cs
public Button button; 
public Text buttonText; 
public string playerSide;
```

UI 버튼은 연결된 스크립트에서 공용 기능을 호출할 수 있습니다. 
버튼을 클릭할 때 Do Something을 위한 공용 함수를 만들어야 합니다. 
이 함수에서 "X" 값을 그리드 공간으로 설정한 다음 상호 작용할 수 없도록 하여 버튼 기능을 비활성화하려고 합니다. 
Button 구성 요소의 상호 작용 가능한 속성을 사용하여 입력을 수락하거나 무시하도록 Button을 설정할 수 있습니다.

- "SetSpace"라는 void를 반환하는 공용 함수를 만듭니다.
- "SetSpace"에서는
  - text 속성을 playerSide에서 "X"로 할당합니다.
  - 버튼 자체를 상호 작용할 수 없도록 만듭니다.
  
```cs
public void SetSpace () 
{ 
     buttonText.text = playerSide; 
     button.interactable = false; 
}
```

이 단원의 뒷부분에서 SetSpace 함수를 호출하도록 그리드 공간의 Button 구성 요소를 설정합니다.

최종 스크립트는 다음과 같아야 합니다.

```cs
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GridSpace : MonoBehaviour {
    public Button button;
    public Text buttonText;
    public string playerSide;
    public void SetSpace ()
    {
        buttonText.text = playerSide;
        button.interactable = false;
    }
}
```
- 스크립트 저장
- 유니티로 돌아가기

이제 Inspector에서 방금 생성한 참조를 설정해야 합니다.
- 프로젝트 창에서 Grid Space 프리팹을 선택합니다.
- Grid Space 프리팹이 선택된 상태에서
  - ... Grid Space 프리팹을 Button 속성으로 드래그합니다.
  - ... Grid Space 프리팹의 자식 Text GameObject를 Button Text 속성으로 드래그합니다
  - ... Player Side 속성을 "X"(또는 테스트하기 위해 선택한 다른 문자열 값)로 설정합니다.
  
그림 설명

그리드 공간 구성 요소를 설정합니다. 이제 Button 자체를 설정해야 합니다.
- 프로젝트 창에서 그리드 공간 프리팹을 선택합니다.
- 그리드 공간 프리팹이 선택된 상태에서
  - ... "+" 버튼을 사용하여 Button 구성 요소의 On Click 목록에 새 행을 추가합니다.
  - ... 그리드 공간 프리팹을 새 행의 개체 필드로 드래그합니다.

그림 설명

Grid Space GameObject가 GridSpace 스크립트의 인스턴스를 운반하고 GridSpace 스크립트의 해당 인스턴스에서 공개 함수를 호출하기를 원하기 때문에 Grid Space 게임 오브젝트를 Button 구성 요소로 끌어오고 있습니다.

- GridSpace 프리팹이 선택된 상태에서
  - Button 구성 요소의 기능 풀다운 목록에서 GridSpace > SetSpace를 선택합니다.

그림 설명

- 씬 저장
- 플레이 모드
- 그리드에서 아무 공간이나 클릭합니다.

그리드 공간을 클릭하면 이제 해당 공간에 Player Side 캐릭터를 할당하고 버튼을 비활성화해야 합니다.

그림 설명

이것은 거의 게임이 아니지만 우리 게임과 게임 플레이의 기초를 제시합니다.

## 5.Controlling the game

이제 이 기본 동작을 게임으로 전환해야 합니다.

이렇게 하려면 게임 컨트롤러를 만들어 컨트롤을 중앙 위치로 이동해야 합니다. 
게임 컨트롤러는 시작 플레이어의 편을 "X" 또는 "O"로 설정하고 누구의 차례인지 추적하고 버튼을 클릭하면 현재 플레이어의 편을 보내고 승자를 확인하고 편을 바꾸거나 종료합니다.

이 작업을 수행하려면 새 스크립트가 필요하므로 자체 GameObject에 연결된 스크립트를 만들어 보겠습니다.
- Create > Create Empty를 사용하여 새 빈 게임 오브젝트를 만듭니다.
- 이 게임 오브젝트의 이름을 "게임 컨트롤러"로 바꿉니다.
- 게임 컨트롤러를 선택한 상태에서
  - ... 게임 컨트롤러의 변환 구성 요소를 재설정합니다.
  - ... "GameController"라는 새 스크립트를 추가합니다.
- Scripts 폴더에 GameController 스크립트를 저장합니다.
- 편집을 위해 GameController 스크립트를 엽니다.

다시 말하지만, 우리는 UI 도구 세트를 사용하고 있으므로 적절한 네임스페이스가 필요합니다.
- 스크립트 상단에 UI 네임스페이스를 추가합니다.
```cs
using UnityEngine.UI;
```
GameController 스크립트는 게임의 모든 버튼에 대해 알아야 상태를 확인하고 그것이 승리했는지 판단할 수 있습니다. 
이를 위해 스크립트는 모든 그리드 공간 버튼 컬렉션을 보유해야 합니다. 
한 행에 3개의 일치하는 값이 있는지 확인하기 위해 Player Side에 대한 버튼의 Text 구성 요소를 확인하려고 할 것이므로 Text 유형의 배열을 만들어 보겠습니다.
- 클래스에서 모든 샘플 코드를 제거합니다.
- "buttonList"라는 공용 텍스트 배열을 만듭니다.
```cs
public Text[] buttonList;
```

유형 뒤의 대괄호 []는 이 변수가 배열임을 나타냅니다.

최종 스크립트는 다음과 같아야 합니다

```cs
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class GameController : MonoBehaviour {
    public Text[] buttonList;
}
```
- 스크립트 저장
- 유니티로 돌아가기

이제 이 버튼 목록 배열을 만들었으므로 그리드 공간 버튼의 텍스트 구성 요소로 채워야 합니다. 
여기서 순서가 중요하다는 것을 기억하십시오. 
부모 그리드 공간 게임 오브젝트가 아닌 버튼 목록 배열에 자식 텍스트 게임 오브젝트를 연결하는 것도 중요합니다.

인스펙터에서 게임 컨트롤러의 버튼 목록 배열을 채우는 한 가지 방법은 배열의 크기를 9로 설정한 다음 각 텍스트 게임 오브젝트를 한 번에 하나씩 배열로 드래그하는 것입니다. 
이것은 약간 지루하고 시간이 많이 걸립니다. 
그러나 이를 수행하는 더 쉬운 방법이 있습니다. 
여기에는 인스펙터 창을 "잠그고" 모든 게임 오브젝트를 한 번에 어레이로 드래그하는 것이 포함됩니다.
- 계층에서 게임 컨트롤러 게임 오브젝트를 선택합니다.
- 인스펙터 창의 오른쪽 상단에서 잠금 버튼을 클릭합니다.

그림 설명

이것이 하는 일은 인스펙터 창이 현재 선택에서 포커스를 변경하는 것을 방지하는 것입니다(이 경우 게임 컨트롤러). 
이 작업을 수행하지 않으면 다음 단계에서 하위 텍스트 게임 오브젝트를 선택할 때 인스펙터의 초점이 이러한 하위 텍스트 게임 오브젝트로 변경되고 게임의 배열로 드래그할 수 없습니다.

또한 여러 개의 Inspector 창을 열어 원하는 창만 잠글 수 있다는 점도 주목할 가치가 있습니다.
이를 통해 계층 구조 및 프로젝트 창에서 다양한 게임 오브젝트의 복잡한 보기가 가능합니다.

- 아래쪽 화살표를 사용하여 Inspector에서 9개의 Grid Space 버튼을 엽니다.
- Windows의 경우 <ctrl> + 클릭 또는 Mac의 경우 <cmd> + 클릭을 사용하여 모든 그리드 공간 게임 개체에서 자식 텍스트 게임 개체만 선택합니다.

그림 설명

- 게임 컨트롤러 게임 오브젝트의 잠긴 인스펙터로 드래그하여 크기 필드 위의 버튼 목록 이름에 놓습니다.

그림 설명

드래그 커서가 올바른 위치에 있으면 커서 옆에 작은 "+" 아이콘이 나타납니다. 
위치를 놓치면 커서가 변경되어 드롭이 실패함을 나타내는 원과 슬래시 아이콘이 표시됩니다.

9개의 텍스트 게임 오브젝트를 성공적으로 드롭하면 자동으로 버튼 목록 배열의 크기가 조정되고 모든 항목이 배열에 추가됩니다.

그림 설명

이 특별한 경우에는 지금 순서를 확인하는 것이 중요합니다. 
자동으로 순서가 지정되어야 하지만 확인하는 것이 좋습니다.
- 요소 필드를 클릭하여 각 요소를 순서대로 선택하십시오.
이렇게 하면 참조로 연결된 GameObject가 강조 표시되어야 합니다.
  
그림 설명

버튼 목록 배열의 각 요소는 올바른 게임 오브젝트에 대응해야 합니다. 
요소 0은 그리드 공간과 연결되어야 하고, 요소 1은 그리드 공간(1)과 연결되어야 하며, 요소 2는 그리드 공간(2)과 연결되어야 합니다.

이것이 맞다면,
- 인스펙터 창을 잠금 해제하십시오.
- 씬을 저장하세요.

이제 플레이어가 턴을 하려면 그리드 공간 버튼이 게임 컨트롤러에 이동이 이루어지고 승리 조건을 확인해야 함을 알려야 합니다. 
즉, 그리드 공간 버튼에는 GameController 구성 요소에 대한 참조가 있어야 합니다. 
이것은 GameController 유형의 로컬 변수에 보관할 수 있습니다.

GameController 구성 요소를 장면의 각 그리드 공간 버튼과 연결하는 한 가지 방법은 이 변수를 공개하고 장면의 각 그리드 공간 버튼 인스턴스에 대해 Inspector에서 이 public 속성을 채우는 것입니다. 
자산이 참조 인스턴스를 보유할 수 없기 때문에 프로젝트 보기의 그리드 공간 프리팹과 장면의 게임 컨트롤러 인스턴스를 연결할 수 없습니다. 
이 모든 드래그는 약간 지루할 수 있지만 프리팹 사용과 관련된 기본 워크플로 중 하나에도 반대합니다. 
프리팹을 장면에 단순히 드롭하고 "그냥 작동"하게 할 수는 없습니다.

그리드 공간 버튼에 대한 참조를 푸시하려면 그리드 공간 스크립트에 GameController 유형의 로컬 변수와 이를 설정하는 공개 함수가 필요합니다.
- 편집을 위해 GridSpace 스크립트를 엽니다.
- GameController에 대한 참조를 저장할 새 개인 변수를 추가합니다.
```cs
private GameController gameController;
```
- GameController를 매개변수로 사용하고 이를 참조로 gameController 변수에 할당할 수 있는 void를 반환하는 새 공개 함수를 만듭니다.
```cs
public void SetGameControllerReference (GameController controller) 
{
     gameController = controller;
}
```
최종 스크립트는 다음과 같아야 합니다.

```cs
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour {

    public Button button;
    public Text buttonText;
    public string playerSide;

    private GameController gameController;

    public void SetGameControllerReference (GameController controller)
    {
        gameController = controller;
    }

    public void SetSpace ()
    {
        buttonText.text = playerSide;
        button.interactable = false;
    }
}
```
- 스크립트 저장
- GameController 스크립트 수정
- "SetGameControllerReferenceOnButtons"라는 void를 반환하는 새 함수를 만듭니다.

```cs
void SetGameControllerReferenceOnButtons () 
{

}
```
SetGameControllerReferenceOnButtons에서 모든 버튼을 반복하는 코드를 작성합니다. 
이것은 buttonList 배열의 모든 요소를 반복하는 for 루프에서 가장 잘 수행됩니다.
```cs
for (int i = 0; i < buttonList.Length; i++) 
{

}
```
루프는 쉽습니다. 
버튼 목록의 전체 길이를 반복하지만... 버튼 목록은 자식 텍스트 게임 오브젝트를 참조하므로 텍스트 게임 오브젝트의 부모에서 GridSpace 구성 요소를 잡아야 합니다. 
어떻게 하면 될까요?

GetComponentInParent를 호출할 수 있는 편리한 방법이 있습니다. 
이를 통해 GetComponentInParent에 유형(우리의 경우 GridSpace)을 제공할 수 있으며 존재하는 경우 해당 구성 요소를 반환합니다.
- 버튼 목록의 각 항목을 확인하는 코드를 추가하고 상위 GameObject의 GridSpace 구성 요소에서 GameController 참조를 설정합니다.
```cs
buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
```
키워드 this는 이 클래스 또는 코드가 작성된 클래스를 나타냅니다. 
이것을 SetGameControllerReference에 전달하면 클래스의 이 인스턴스에 대한 참조를 전달합니다. 
각 GridSpace 인스턴스는 이를 사용하여 GameController에 대한 참조를 설정합니다.

이제 게임이 시작될 때 SetGameControllerReferenceOnButtons 함수를 호출해야 합니다
- void를 반환하는 Awake 함수를 만듭니다.
- SetGameControllerReferenceOnButtons를 호출합니다.

```cs
void Awake () 
{
     SetGameControllerReferenceOnButtons();
}
```

이제 버튼이 GameController에 대해 알고 적절한 참조가 있으므로 버튼이 두 가지 작업을 수행하기를 원합니다. 
그리드 공간으로 이동하고, 일단 완료되면 게임 컨트롤러가 이제 턴이 끝났음을 알리고 게임 컨트롤러가 승리 조건을 확인하고 게임을 종료하거나 턴을 진행하는 쪽을 변경할 수 있도록 합니다.

이렇게 하려면 GameController 스크립트에서 추가 기능을 설정해야 합니다.
- 편집을 위해 GameController 스크립트를 엽니다.
- "GetPlayerSide"라는 문자열을 반환하는 비어 있는 새 공용 함수를 만듭니다.
```cs
public string GetPlayerSide () 
{
     return "?";
}
```
성공적으로 컴파일하려면 GetPlayerSide가 일부 문자열 값을 반환해야 하므로 여기에 "?"를 반환하는 더미 줄을 추가합니다.
- "EndTurn"이라는 void를 반환하는 비어 있는 새 공용 함수를 만듭니다.
```cs
public void EndTurn () 
{ 
     Debug.Log("EndTurn is not implemented!"); 
}
```

개발의 이 단계에서 두 개의 본질적으로 빈 함수를 생성한 방법에 유의하십시오.
우리는 이러한 기능이 수행하기를 원하는 기본 아이디어를 알고 있지만 아직 콘텐츠를 개발하지 않았습니다. 
나중에 "채울" 수 있지만 이러한 비어 있지만 실행 가능한 함수를 만들어 아직 자세히 생각할 준비가 되지 않은 다른 코드의 얽힘에 빠지지 않고 게임의 다른 부분에서 개발을 계속할 수 있습니다. 
이 두 함수 모두 테스트를 위해 게임을 실행하면 완료되지 않는다는 표시기가 있습니다.
GetPlayerSide는 "?"를 반환합니다.
그리고 EndTurn은 "EndTurn이 구현되지 않았습니다!"라는 경고를 콘솔에 출력합니다.
이렇게 하면 나중에 돌아가서 이러한 기능에 대해 작업해야 한다는 점을 분명히 알 수 있습니다.

최종 스크립트는 아래와 같습니다.

```cs
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public Text[] buttonList;

    void Awake ()
    {
        SetGameControllerReferenceOnButtons();
    }

    void SetGameControllerReferenceOnButtons ()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public string GetPlayerSide ()
    {
        return "?";
    }

    public void EndTurn ()
    {
        Debug.Log("EndTurn is not implemented!");
    }
}
```
- 스크립트 저장  
GameController의 이 두 가지 새로운 공개 함수를 사용하여 GridSpace에서 사용해야 합니다.
- 편집을 위해 GridSpace 스크립트를 엽니다.
- SetSpace 함수에서,
  - ... 첫 번째 줄을 변경하여 buttonText.text에 GameController의 현재 값에서 직접 GetPlayerSide 값을 할당합니다.
```cs
buttonText.text = gameController.GetPlayerSide();
```
- SetSpace 함수에서
  - 함수의 마지막 줄에 EndTurn을 호출하는 줄을 추가합니다
```cs
buttonText.text = gameController.GetPlayerSide();
gameController.EndTurn();
```

이 시점에서 함수의 코드는 위에서 아래로 순서대로 실행된다는 것을 기억할 가치가 있습니다. 
따라서 함수의 끝에 EndTurn을 호출하면 다른 모든 코드 후에 마지막으로 호출된다는 것을 알 수 있습니다. 
SetSpace에서 비즈니스가 완료되었습니다.

우리는 이제 더 이상 플레이어 라인을위한 지역 변수가 필요하지 않습니다.
이 값은 현재 게임 컨트롤러에서 직접 가져옵니다.
- playerSide 변수를 정의하는 줄을 제거합니다.
```cs
public string playerSide;
```

최종 스크립트는 아래와 같습니다.

```cs
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour {

    public Button button;
    public Text buttonText;

    private GameController gameController;

    public void SetGameControllerReference (GameController controller)
    {
        gameController = controller;
    }

    public void SetSpace ()
    {
        buttonText.text = gameController.GetPlayerSide();
        button.interactable = false;
        gameController.EndTurn();
    }
}
```
- 스크립트를 저장하십시오.
- 유니티로 돌아가십시오.
- 플레이 하십시오.
- 공백 중 하나를 클릭하여 테스트합니다.

이제 모든 것이 적어도 기술적으로 작동하는지 확인해야 합니다. 
공백이 "?" 게임 컨트롤러와 매 턴마다 우리 콘솔은 "EndTurn이 구현되지 않았습니다!"라고 말하지만 플레이어 측 값은 이제 게임 컨트롤러에서 가져오고 플레이어가 버튼을 클릭하여 이동하면 게임 제어가 다시 전달됩니다.
차례를 처리하기 위해 게임 컨트롤러에. 이제 기본 게임 플레이 동작을 버튼 요소 자체에서 제거하고 확장하여 이제 중앙 지점에서 전반적인 제어를 할 수 있습니다.

다음 수업에서 우리는 승리를 위해 게임을 테스트할 것입니다.

## 6.Win conditions and taking turns

우리는 보드의 그리드 공간을 테스트하고 승리가 있었는지 확인해야 합니다.
플레이어 측이 제대로 설정되지 않았지만 그리드 공간의 Text 속성을 확인하여 문자열 값이 "연속 3개"와 일치하고 이 값이 현재 재생 중인 쪽과 일치하는지 확인해야 합니다.
이렇게 하려면 현재 재생 중인 진영을 나타내는 캐릭터를 보유할 변수가 필요합니다. 
이 변수는 교대로 회전하면서 결국 변경되지만 지금은 상수 값입니다.
게임이 시작될 때 이 값을 설정해야 하며 "?" 대신 GetPlayerSide에서 이 값을 반환해야 합니다.
- 편집을 위해 GameController 스크립트를 엽니다.
- "playerSide"라는 개인 문자열 변수를 정의하십시오.
```cs
private string playerSide;
```
- Awake에서 playerSide를 "X"로 설정합니다
```cs
playerSide = "X";
```
- GetPlayerSide에서 "?" 대신 playerSide를 반환합니다.
```cs
return playerSide;
```

이제 GetPlayerSide를 호출할 때 playerSide를 GridSpace로 보내고, 측면을 교체할 때 현재 플레이어의 측면을 보내도록 설정합니다.
다음 단계는 승리를 확인하는 것입니다.
- EndTurn에서 Debug.Log 줄을 제거합니다.
```cs
Debug.Log("End Turn is not implemented");
```
승리를 확인하려면 보드의 3행, 3열, 2개의 대각선을 살펴보고 모든 시리즈의 격자 공간 3개가 모두 일치하는지 확인해야 합니다.

이 게임은 무차별 대입을 사용하여 승리 조건을 테스트하기에 충분히 작습니다. 
우리는 단순히 행을 확인하고 세 개의 공간이 현재 플레이어의 값과 비교하여 세 개의 공간이 모두 현재 플레이어와 일치하는지 확인할 수 있습니다.

이 코드 줄은 EndTurn 함수로 이동해야 하므로 EndTurn을 호출할 때 현재 플레이어가 게임에서 이겼는지 확인합니다. 
이것은 다소 복잡한 if 문을 만들어 수행됩니다. button0이 playerSide인지, button1이 playerSide인지, button2가 playerSide인지 확인합니다. 
이 모든 것이 사실이면 우리는 승리합니다.
- EndTurn 함수에 첫 번째 행을 확인하는 코드를 추가합니다.
```cs
if (buttonList [0].text == playerSide && buttonList [1].text == playerSide && buttonList [2].text == playerSide) 
{

}
```

이 코드 줄에서 맨 위 행을 확인하여 세 개의 공백이 모두 현재 플레이어와 일치하는지 확인합니다. 
이것이 우리가 어떤 버튼이 어떤 공간에 있는지 정확히 알아야 하는 이유입니다. 
그리드 공간이 왼쪽에서 오른쪽으로, 위에서 아래로 순서가 있다는 것을 알고 있으므로 buttonList [0], buttonList [1] 및 buttonList [2]의 텍스트 값을 확인하여 맨 위 행의 값을 확인할 것입니다.

그림 설명

이제 행, 열 또는 대각선이 승리에 대해 true로 테스트되면 게임을 종료하기 위해 몇 가지 작업을 수행해야 합니다. 
최소한 게임을 계속할 수 없고 사용하지 않는 버튼을 클릭할 수 없도록 보드의 모든 버튼을 비활성화해야 합니다.

따라서 승리 조건이 충족되면 "Game Over" 로직을 모두 수행할 수 있는 함수를 호출해 보겠습니다.

- "GameOver"라는 void를 반환하는 함수를 추가합니다.

```cs
void GameOver () 
{

}
```

게임이 끝났을 때 우리가 취하고자 하는 첫 번째 행동은 사용하지 않는 모든 버튼을 끄는 것입니다. 
이렇게 하려면 각 버튼에 액세스해야 합니다. 
buttonList를 통해 이 작업을 수행할 수 있습니다. 
상호 작용 가능한지 여부를 확인하기 위해 각 버튼을 실제로 테스트할 필요가 없습니다. 
이것은 실행할 때 자원을 낭비하고 코딩할 때 시간을 낭비합니다. 
buttonList의 모든 요소를 반복하여 모든 버튼을 상호 작용할 수 없도록 간단히 설정할 수 있습니다. 
이미 수행한 이동으로 인해 해당 버튼이 이미 상호 작용할 수 없는 경우에는 계속 상호 작용할 수 없습니다. 
속성은 단순히 상호 작용할 수 없는 동일한 값으로 설정됩니다. 
이것은 한 줄의 스위치를 손으로 실행하고 모든 스위치를 끄는 것과 같습니다. 
그들이 처음에 켜져 있었는지 꺼져 있었는지 여부는 중요하지 않습니다.
- GameOver 함수에서 buttonList의 모든 요소를 반복하는 새로운 for 루프를 만듭니다.
```cs
for (int i = 0; i < buttonList.Length; i++) {

}
```
- for 루프에서 목록의 각 요소에 대해 상위 GameObject의 Button 구성 요소를 찾아 상호 작용할 수 없도록 만들어 버튼을 비활성화합니다.
```cs
buttonList[i].GetComponentInParent<Button>().interactable = false;
```
이제 이 코드를 실행하기 위해 승리 조건이 충족되면 GameOver를 호출해야 합니다.
- EndTurn의 if 문에서 GameOver에 대한 호출을 추가합니다.

최종 스크립트는 다음과 같습니다.

```cs
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public Text[] buttonList;

    private string playerSide;

    void Awake ()
    {
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
    }

    void SetGameControllerReferenceOnButtons ()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);

        }
    }

    public string GetPlayerSide ()
    {
        return playerSide;
    }

    public void EndTurn ()
    {
        if (buttonList [0].text == playerSide && buttonList [1].text == playerSide && buttonList [2].text == playerSide)
        {
            GameOver();
        }
    }

    void GameOver ()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }
    }
}
```
- 스크립트 저장
- 유니티 돌아가기
- 플레이
- 공백의 맨 위 행을 클릭하여 테스트합니다.

맨 위 행의 세 공간을 모두 클릭하면 코드가 승리를 감지해야 합니다. 
이 시점에서 나머지 버튼은 모두 비활성화되어야 합니다. 
현재 다른 행, 열 또는 대각선 중 하나를 클릭하여 "승리"하려고 하면 게임이 승패를 감지하지 못합니다. .

이제 나머지 행, 열 및 대각선을 확인해야 합니다.
- 편집을 위해 GameController 스크립트를 엽니다.

첫 번째 행을 확인하는 코드가 이미 있습니다. 이를 위해 코드는 다음 요소를 확인합니다.

buttonList [0], buttonList [1] and buttonList [2]

이제 나머지 가능한 조합을 확인해야 합니다.

buttonList [3], buttonList [4] and buttonList [5] buttonList [6], buttonList [7] and buttonList [8]

... 다음에 열:

buttonList [0], buttonList [3] and buttonList [6] buttonList [1], buttonList [4] and buttonList [7] buttonList [2], buttonList [5] and buttonList [8]

... 그리고 마지막으로 두 개의 대각선:

buttonList [0], buttonList [4] and buttonList [8] buttonList [2], buttonList [4] and buttonList [6]

그림 설명

- 첫 번째 행을 7번 검사하는 코드를 복제하므로 총 8개의 사본이 있습니다. 각 열, 행 및 대각선에 대해 하나의 if 문.
```cs
if (buttonList [0].text == playerSide && buttonList [1].text == playerSide && buttonList [2].text == playerSide) { 
     GameOver(); 
}
```

- 각 if 문이 고유한 행, 열, 행 또는 대각선을 검사하도록 각 행, 열, 행 및 대각선에 대한 인덱스 값 [ ]을 변경합니다. (위의 열, 행 및 대각선 목록을 참조하십시오.) 예를 들어 다음은 두 번째 행을 확인하는 선입니다.
```cs
if (buttonList [3].text == playerSide && buttonList [4].text == playerSide && buttonList [5].text == playerSide) { 
     GameOver(); 
}
```

최종 스크립트는 다음과 같습니다.

```cs
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public Text[] buttonList;

    private string playerSide;

    void Awake ()
    {
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
    }

    void SetGameControllerReferenceOnButtons ()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public string GetPlayerSide ()
    {
        return playerSide;
    }

    public void EndTurn ()
    {
        if (buttonList [0].text == playerSide && buttonList [1].text == playerSide && buttonList [2].text == playerSide)
        {
            GameOver();
        }

        if (buttonList [3].text == playerSide && buttonList [4].text == playerSide && buttonList [5].text == playerSide)
        {
            GameOver();
        }

        if (buttonList [6].text == playerSide && buttonList [7].text == playerSide && buttonList [8].text == playerSide)
        {
            GameOver();
        }

        if (buttonList [0].text == playerSide && buttonList [3].text == playerSide && buttonList [6].text == playerSide)
        {
            GameOver();
        }

        if (buttonList [1].text == playerSide && buttonList [4].text == playerSide && buttonList [7].text == playerSide)
        {
            GameOver();
        }

        if (buttonList [2].text == playerSide && buttonList [5].text == playerSide && buttonList [8].text == playerSide)
        {
            GameOver();
        }

        if (buttonList [0].text == playerSide && buttonList [4].text == playerSide && buttonList [8].text == playerSide)
        {
            GameOver();
        }

        if (buttonList [2].text == playerSide && buttonList [4].text == playerSide && buttonList [6].text == playerSide)
        {
            GameOver();
        }
    }

    void GameOver ()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }
    }
}
```
- 스크립트 저장
- 유니티로 돌아가기
- 플레이
- 공백 중 하나를 클릭하여 테스트합니다.

이제 가능한 모든 승리 조건이 작동해야 하며 승리 조건이 충족되면 보드가 비활성화되어야 합니다.

다음으로, 턴이 완료되고 실제로 다른 사람과 플레이할 수 있을 때 측면을 변경해야 합니다.

현재로서는 게임이 없습니다. 
우리는 승리 조건을 확인할 수 있고 연속으로 3개의 "X"가 나오면 게임이 종료됩니다. 
이제 우리는 측면을 바꿀 수 있어야 합니다. 
편을 바꾸려면 우리가 어느 편에 있는지 확인하고 플레이어 값을 바꿔야 합니다. 
"X"를 "O"로 바꾸거나 그 반대의 경우도 마찬가지입니다.

이를 위해 플레이어 측면을 변경하는 함수를 생성해 보겠습니다.
- "ChangeSides"라는 void를 반환하는 새 함수를 만듭니다.
```cs
void ChangeSides () 
{

}
```

그 기능에서 우리는 현재 팀을 테스트하고 플레이어의 팀을 교체해야 합니다.
- playerSide 값을 확인하는 코드를 추가하고 다른 팀의 값을 playerSide에 할당합니다.
```cs
playerSide = (playerSide == "X") ? "O" : "X"; // Note: Capital Letters for "X" and "O"
```
턴이 끝날 때마다 면을 변경해야 하므로 EndTurn 함수의 끝에 ChangeSides를 호출해 보겠습니다.

최종 스크립트는 다음과 같아야 합니다.

```cs
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public Text[] buttonList;

    private string playerSide;

    void Awake ()
    {
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
    }

    void SetGameControllerReferenceOnButtons ()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public string GetPlayerSide ()
    {
        return playerSide;
    }

    public void EndTurn ()
    {

        if (buttonList [0].text == playerSide && buttonList [1].text == playerSide && buttonList [2].text == playerSide)
        {
            GameOver();
        }

        if (buttonList [3].text == playerSide && buttonList [4].text == playerSide && buttonList [5].text == playerSide)
        {
            GameOver();
        }

        if (buttonList [6].text == playerSide && buttonList [7].text == playerSide && buttonList [8].text == playerSide)
        {
            GameOver();
        }

        if (buttonList [0].text == playerSide && buttonList [3].text == playerSide && buttonList [6].text == playerSide)
        {
            GameOver();
        }

        if (buttonList [1].text == playerSide && buttonList [4].text == playerSide && buttonList [7].text == playerSide)
        {
            GameOver();
        }

        if (buttonList [2].text == playerSide && buttonList [5].text == playerSide && buttonList [8].text == playerSide)
        {
            GameOver();
        }

        if (buttonList [0].text == playerSide && buttonList [4].text == playerSide && buttonList [8].text == playerSide)
        {
            GameOver();
        }

        if (buttonList [2].text == playerSide && buttonList [4].text == playerSide && buttonList [6].text == playerSide)
        {
            GameOver();
        }

        ChangeSides();

    }

    void ChangeSides ()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
    }

    void GameOver ()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }
    }
}
```
- 스크립트 저장
- 유니티로 돌아가기
- 플레이 하기
- 테스트 진행

이제 아무 공간이나 클릭하면 "X"와 "O"가 번갈아가며 차례대로 "X" 또는 "O"가 3개 연속으로 나오면 승리 조건을 충족하고 게임이 종료됩니다.

우리 게임은 본질적으로 끝났습니다! 
이 단계에서는 실제로 Tic-Tac-Toe를 재생할 수 있습니다. 
그러나 다음 단계는 사람들이 완료되고 플레이할 가치가 있다고 느끼는 적절한 게임으로 프로젝트를 다듬는 것입니다.

## 7.Game Over text

이제부터 우리는 본질적으로 게임을 다듬고 표현 가능하게 만들고 있습니다.

제작 관점에서 볼 때 단순히 기본 게임 및 게임 플레이를 제작하는 것과 비교하여 게임을 연마하는 데 얼마나 많은 시간이 소요되는지 주목할 가치가 있습니다.

이것은 새로운 게임 개발자에게 일반적인 간과입니다.

기본 게임 플레이가 빠르게 결합됩니다... 터널 끝에 빛이 있고... 그리고... 예기치 않게... 세련되고 멋진 게임을 만들기 위한 긴 오르막이 있습니다. 
흥미롭게도 흥미롭고 어려운 문제는 모두 해결되었습니다. 남은 것은 끝없는 조정과 연마의 바다뿐입니다...

이 시점에서 낙심하기 쉽습니다. 하지만. 우리는 어떤 제품을 연마하고 발표하는 것이 기본 기능을 하는 제품 자체를 생산하는 것보다 더 오래 걸리거나 더 오래 걸린다는 것을 항상 기억해야 합니다.

"Game Over" 텍스트 요소를 생성하여 다듬기를 시작하겠습니다.
- 만들기 > UI > 패널을 사용하여 장면에 새 UI 패널 요소를 만듭니다.
- 패널을 선택한 상태에서
  - GameObject의 이름을 "Game Over Panel"로 바꿉니다.
  - .. Anchor, Pivot 및 Position을 중간/중앙으로 설정합니다.
  - ... 너비를 440으로 설정합니다.
  - ... 높이를 100으로 설정합니다.
  - ... 색상을 보드와 유사한 진한 파란색으로 설정합니다(33, 44, 55, 196).

색상을 설정하려면 색상 선택기 패널에서 사전 설정 색상 견본을 사용한 다음 알파 채널 값을 196으로 변경할 수 있습니다.

다음으로 패널에 UI 텍스트 요소를 추가하려고 합니다. 
Hierarchy Window의 Create 메뉴를 사용하여 생성할 수 있지만, 이는 단순히 UI Text 요소를 루트 Canvas에 추가하는 것입니다.

그림 설명

이것은 작동하지만 새 UI 텍스트 요소를 Game Over Panel로 드래그하여 자식으로 만들어야 합니다.

단계를 줄이기 위해 UI Text 요소를 직접 자식으로 만들 수 있습니다.
- 계층 구조 창에서 게임 오버 패널을 마우스 오른쪽 버튼으로 클릭합니다.

그러면 상황에 맞는 메뉴가 열립니다. 이 메뉴에서 UI > 텍스트를 선택합니다.

그림 설명

UI 요소를 선택하고 상황에 맞는 메뉴를 사용할 때 Unity에 새 UI 요소를 자식으로 만들고 싶다고 표시합니다.

그림 설명

이제 한 단계로 UI Text 요소를 Game Over Panel의 자식으로 만들었습니다.
- Text GameObject를 선택합니다.
- Text GameObject를 선택한 상태에서
  - ... Anchor, Pivot 및 Position을 늘이기 위해 설정합니다.
  - ... 텍스트를 "Win Text"로 설정합니다.
  - ... 글꼴 크기를 64로 설정합니다.
  - ... 정렬을 중간/중앙으로 설정합니다.
  - ... 사전 설정을 사용하여 색상을 파란색(0, 204, 204, 255)으로 설정합니다.

그림 설명

- 장면 저장

이제 이 UI 패널과 UI 텍스트 요소를 제어해야 합니다.

- 편집을 위해 GameController 스크립트를 엽니다.

Game Over Panel과 관련된 Text 요소를 보유하고 있는 GameObject에 대한 참조가 필요합니다. 
게임 시작 시 Game Over Panel이 비활성화되어 있는지 확인해야 합니다. 
마지막으로 Game Over Panel을 활성화하고 게임이 끝나면 Text 값을 설정하려고 합니다.
- Game Over 패널에 대한 공개 GameObject 변수를 만듭니다.
- 연결된 Text 구성 요소에 대한 공용 변수를 만듭니다.
```cs
public GameObject gameOverPanel; public Text gameOverText;
```
- Awake에서 gameOverPanel을 Inactive로 설정합니다.
```cs
gameOverPanel.SetActive(false);
```
- GameOver에서
  - ... gameOverPanel"을 활성으로 설정합니다.
  - ... 승자를 표시하도록 gameOverText.text" 속성을 설정합니다.
```cs
gameOverPanel.SetActive(true); 
gameOverText.text = playerSide + " Wins!"; // Note the space after the first " and Wins!"
```

최종 스크립트는 다음과 같아야 합니다.

```cs
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public Text[] buttonList;
    public GameObject gameOverPanel;
    public Text gameOverText;

    private string playerSide;

    void Awake ()
    {
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
        gameOverPanel.SetActive(false);
    }

    void SetGameControllerReferenceOnButtons ()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public string GetPlayerSide ()
    {
        return playerSide;
    }

    public void EndTurn ()
    {

        if (buttonList [0].text == playerSide && buttonList [1].text == playerSide && buttonList [2].text == playerSide)
        {
            GameOver();
        }

        if (buttonList [3].text == playerSide && buttonList [4].text == playerSide && buttonList [5].text == playerSide)
        {
            GameOver();
        }

        if (buttonList [6].text == playerSide && buttonList [7].text == playerSide && buttonList [8].text == playerSide)
        {
            GameOver();
        }

        if (buttonList [0].text == playerSide && buttonList [3].text == playerSide && buttonList [6].text == playerSide)
        {
            GameOver();
        }

        if (buttonList [1].text == playerSide && buttonList [4].text == playerSide && buttonList [7].text == playerSide)
        {
            GameOver();
        }

        if (buttonList [2].text == playerSide && buttonList [5].text == playerSide && buttonList [8].text == playerSide)
        {
            GameOver();
        }

        if (buttonList [0].text == playerSide && buttonList [4].text == playerSide && buttonList [8].text == playerSide)
        {
            GameOver();
        }
        if (buttonList [2].text == playerSide && buttonList [4].text == playerSide && buttonList [6].text == playerSide)
        {
            GameOver();
        }
        ChangeSides();
    }

    void ChangeSides ()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
    }

    void GameOver ()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }
        gameOverPanel.SetActive(true);
        gameOverText.text = playerSide + " Wins!";
    }
}
```
- 스크립트 저장
- 유니티 돌아가기

이제 GameController 스크립트에서 만든 변수에 새 패널과 텍스트를 할당해야 합니다.
- 계층 창에서 게임 컨트롤러를 선택합니다.
- 게임 컨트롤러를 선택한 상태에서
  - .. Game Over Panel 속성을 할당합니다.
  - ... Game Over Text 속성을 할당합니다.

그림 설명

- 장면 저장
- 플레이
- 테스트

이제 어느 팀에서든 3연패를 당하면 게임이 끝났고 누가 이겼는지에 대한 명확한 안내를 받아야 합니다.

그림 설명

다음 수업에서는 아무도 이기지 않고 게임이 무승부인 경우를 다룰 것입니다.

## 8.Ending in a draw

이제 승리를 처리할 수 있는 좋은 방법이 생겼습니다. 하지만 무승부라면 어떻게 될까요? 아니면 넥타이?

자, 솔직히 말해서, 대부분의 Tic-Tac-Toe 게임은 동점 또는 무승부로 끝납니다. 
이를 설명하기 위해 다른 무차별 대입 솔루션이 가장 좋습니다. 
매 턴마다 모든 타일을 폴링하여 buttonList의 모든 Button 구성 요소가 상호 작용할 수 없는지 확인하여 모든 그리드 공간이 "사용"되었는지 확인할 수 있습니다.
반면에 우리는 단순히 이동 횟수를 셀 수 있습니다. 이동 횟수가 9이고 아무도 이기지 못했다면 무승부입니다.
- 편집을 위해 GameController 스크립트를 엽니다.
- "moveCount"라는 private int 변수를 선언합니다.
```cs
private int moveCount;
```
- Awake에서 moveCount를 0으로 설정합니다.
```cs
moveCount = 0;
```
- EndTurn에서 함수 상단에서 moveCount를 1씩 증가시킵니다.
```cs
moveCount++;
```

함수 끝의 EndTurn에서 변을 바꾸기 전에 moveCount를 확인하고 9 이상이면 gameOverPanel을 활성화하고 gameOverText를 설정합니다.

```cs
if (moveCount >= 9) 
{ 
     gameOverPanel.SetActive(true); 
     gameOverText.text = "It's a draw!"; 
}
```

한 가지 걱정거리가 있지만...

코드를 볼 때 Game Over Panel의 상태와 그 내용을 두 곳에서 설정하고 있습니다. 
무승부라면 EndTurn에서 한 번, 이기면 GameOver에서 다시 한 번. 이것은 저를 걱정하게 하며 이것은 모범 사례가 아닙니다. 
뭔가를 한다는 논리가 있다면 한 곳에 있어야 합니다.

여기에는 몇 가지 이유가 있지만 주로 코드 유지 관리의 용이성과 코드를 읽을 때 코드를 이해하기 쉽기 때문입니다.
코드 유지 관리는 매우 중요합니다.
소프트웨어 프로젝트를 개발할 때 버그를 빠르게 찾고 수정할 수 있어야 합니다.
그러나 더 중요한 것은 프로젝트를 개선하거나 새 기능이나 다른 기능으로 업그레이드할 때 가능한 한 간단한 방법으로 기능을 쉽게 찾고 변경하려는 것입니다. 
우리의 논리가 코드베이스 전체에 퍼져 있으면 찾기가 어려울 뿐만 아니라 논리 또는 기능의 모든 인스턴스를 찾았는지 확인하고 수정하기가 매우 어렵습니다.

Game Over Text를 설정하는 이 코드를 예로 들어 보겠습니다.
Game Over Text가 설정되는 방식이나 해당 텍스트의 내용을 변경하려면 이것이 두 개의 다른 위치에 설정되어 있음을 기억하고 둘 다 수정해야 합니다. 
그렇지 않으면 플레이어가 게임을 할 때만 발견할 수 있는 버그가 있습니다. 그건 좋지 않다.

이제 프로젝트가 완료되면 작동하고 배송 가능하며 그 자체로 성공입니다.
포인트 릴리스를 위해 기존 프로젝트에 새 기능을 추가하거나 원본을 기반으로 한 새 버전을 위해 프로젝트를 재사용하는 것은 훨씬 더 큰 성공입니다.
깨끗하고 재사용 가능한 코드를 통해 이 모든 작업과 그 이상의 작업을 수행할 수 있습니다. 
깨끗하고 재사용 가능한 코드는 시간과 좌절을 줄여줍니다. 
코드가 깨끗하고 이해하기 쉬우며 재사용 가능하다면 좋은 코드입니다.

이를 염두에 두고 이 모든 논리를 한 곳에 모아 보겠습니다.
- 편집을 위해 GameController 스크립트를 엽니다.
- 문자열 값을 매개변수로 사용하는 "SetGameOverText"라는 void를 반환하는 새 함수를 만듭니다.

```cs
void SetGameOverText(string value) 
{

}
```
GameOver에서 SetGameOverText로 코드를 복사하고 함수의 문자열 값 매개변수를 사용하도록 조정합니다.
```cs
gameOverPanel.SetActive(true); 
gameOverText.text = value;
```
- gameOverPanel을 활성화하고 EndTurn에서 gameOverText를 설정하는 코드를 제거하고 "It's a draw!"가 있는 SetGameOverText 호출로 대체합니다. 인수로.
```cs
SetGameOverText("It's a draw!");
```
- GameOver에서 동일한 코드를 제거하고 SetGameOverText에 대한 호출로 대체합니다.
```cs
SetGameOverText(playerSide + " Wins!");
```

최종 스크립트는 다음과 같아야 합니다.
```cs
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public Text[] buttonList;
    public GameObject gameOverPanel;
    public Text gameOverText;

    private string playerSide;
    private int moveCount;

    void Awake ()

    {
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
        gameOverPanel.SetActive(false);
        moveCount = 0;
    }

    void SetGameControllerReferenceOnButtons ()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public string GetPlayerSide ()
    {
        return playerSide;
    }

    public void EndTurn ()
    {
        moveCount++;
        if (buttonList [0].text == playerSide && buttonList [1].text == playerSide && buttonList [2].text == playerSide)
        {
            GameOver();
        }

        if (buttonList [3].text == playerSide && buttonList [4].text == playerSide && buttonList [5].text == playerSide)
        {
            GameOver();
        }

        if (buttonList [6].text == playerSide && buttonList [7].text == playerSide && buttonList [8].text == playerSide)
        {
            GameOver();
        }

        if (buttonList [0].text == playerSide && buttonList [3].text == playerSide && buttonList [6].text == playerSide)
        {
            GameOver();
        }

        if (buttonList [1].text == playerSide && buttonList [4].text == playerSide && buttonList [7].text == playerSide)
        {
            GameOver();
        }

        if (buttonList [2].text == playerSide && buttonList [5].text == playerSide && buttonList [8].text == playerSide)
        {
            GameOver();
        }

        if (buttonList [0].text == playerSide && buttonList [4].text == playerSide && buttonList [8].text == playerSide)
        {
            GameOver();
        }

        if (buttonList [2].text == playerSide && buttonList [4].text == playerSide && buttonList [6].text == playerSide)
        {
            GameOver();
        }

        if (moveCount >= 9)
        {
            SetGameOverText ("It's a draw!");
        }

        ChangeSides();
    }

    void ChangeSides ()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
    }

    void GameOver ()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }
        SetGameOverText (playerSide + " Wins!");
    }

    void SetGameOverText (string value)
    {
        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }
}
```
- 스크립트 저장
- 유니티 돌아가기
- 플레이
- 테스트
  
자기 자신과의 경기에서 무승부를 거두는 것은 의외로 어렵죠? 
한 쪽이 이기면 Game Over Text에 승자와 승자를 표시해야 합니다. 
무승부라면 Game Over Text는 "무승부입니다!"라고 말해야 합니다.

그림 설명

테스트 하려면 플레이 모드를 종료하고 들어가 수동으로 게임을 다시 시작 해야 합니다.
게임이 완료되면 애플리케이션을 다시 시작하지 않고 원하는 만큼 계속 플레이할 수 있기를 원할 것입니다. 
다음 강의에서는 게임을 재설정하고 다시 시작하는 방법을 다룰 것입니다.

## Getting Started

Download links:

SSH clone URL: ssh://git@git.jetbrains.space/lonpeach/pg/tic-tac-toe-playground.git

HTTPS clone URL: https://git.jetbrains.space/lonpeach/pg/tic-tac-toe-playground.git

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

## Prerequisites

What things you need to install the software and how to install them.

```
Examples
```

## Deployment

Add additional notes about how to deploy this on a production system.

## Resources

Add links to external resources for this project, such as CI server, bug tracker, etc.
