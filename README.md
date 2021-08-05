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
