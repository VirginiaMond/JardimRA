# GardenAR - Aplicativo de AR para jardinagem

## Autoria
Desenvolvido por:  
Yasmin Cantanhede Santos e Virgínia Maria Mondêgo Ferreira  
Data: Janeiro/2026

## Resumo do projeto
Aplicativo móvel Android desenvolvido para a disciplina de Computação Gráfica do curso de Engenharia da Computação/UFMA. O objetivo é auxiliar na visualização de jardinagem, permitindo que o usuário insira modelos 3D de plantas (como cactos,árvore e flores) no ambiente real antes do plantio, utilizando a câmera do celular.

## Instruções de uso
1. Instale o arquivo .apk em um dispositivo Android compatível.
2. Abra o aplicativo e conceda a permissão de uso da câmera.
3. Aponte o celular para o chão e mova-o lentamente para que o sistema detecte a superfície (uma grade visual aparecerá).
4. Toque na tela sobre a grade detectada para "plantar" o modelo 3D no local.
5. Clique no botão para selecionar outro tipo de planta e refaça o passo 4.

## Requisitos técnicos
- Sistema Operacional: Android 7.0 (Nougat) ou superior.
- Hardware: Dispositivo compatível com Google ARCore.
- Espaço em Disco: Aproximadamente 50 MB.

## Tecnologias e créditos
- Engine: Unity 2022.3 LTS.
- AR Framework: AR Foundation & Google ARCore XR Plugin.
- Linguagem de Programação: C#.
- Assets 3D: "Pandazole Nature Environment" (Unity Asset Store).


# Tutorial completo: Projeto GardenAR
Este documento resume todo o desenvolvimento do aplicativo GardenAR, resultando em um aplicativo de realidade aumentada, otimizado para dispositivos Android modernos, com interface funcional (botão de troca de itens e botão de remoção) e interação com objetos 3D.
### 1. O script principal

No Unity, criamos um script C# chamado `Plantador`.

Apagou-se todo o conteúdo advindo do script e escreveu-se o código correspondente para obter o toque na tela, a lista com 10 plantas e a função de remover.
O script `Plantador` encontra-se na pasta `Assets> Plantador.cs`

### 2. Preparando as plantas (assets)
Utilizou-se o pacote Pandazole Nature Environment.

**Importação:**  
Baixou-se o pacote pelo Package Manager (saindo do Play Mode antes de importar).

**Ajuste de escala:**
- Arrastou-se a planta para a cena.
- Mudou a Scale para 0.1 ou 0.2 (X, Y, Z).
- Arrastou-se de volta para a pasta para criar um Prefab Variant.
- Deletou-se da cena.
- Repetiu esse processo para criar os 10 itens diferentes.

**Configurar a lista:**
- No XR Origin, no script `Plantador` criado, definiu-se o tamanho da lista para 10.
- Arrastou-se os 10 prefabs ajustados para os espaços vazios.

### 3. Interface (UI) e botões:
Para evitar que os botões fiquem pequenos ou mal posicionados, utilizou-se:

**Canvas:**
- No objeto Canvas, no componente Canvas Scaler, mudou-se para *Scale With Screen Size*.

**Botão "Próxima planta":**
- Posição: Âncora no canto superior direito (Shift + Alt).
- Ajuste: Pos X = -200, Pos Y = -150.
- Tamanho: Width = 300, Height = 80.
- Texto: Fonte tamanho 35 ou 40 (sem Auto Size).
- Função: OnClick() → XR Origin → `Plantador.MudarPlanta`.

**Botão "remover":**
- Posição: Âncora no canto superior esquerdo (Shift + Alt).
- Ajuste: Pos X = 200, Pos Y = -150.
- Tamanho: Width = 300, Height = 80.
- Texto: Fonte tamanho 35 ou 40.
- Função: OnClick() → XR Origin → `Plantador.RemoverUltimaPlanta`.

### 4. Alteração da cor do AR Plane
Para remover a coloração amarela padrão, fez-se:
- Criação de um novo Material (`MaterialChao`).
- Alteração no modo para *Transparent*.
- Definiu-se a cor branca e o Alpha (A) em 30.
- Aplicou-se este material no prefab `AR Default Plane`.

### 5. Configurações de build
Essas configurações são essenciais para o funcionamento correto do APK em dispositivos modernos.

Caminho usado:  
`Edit > Project Settings > Player > Android > Other Settings`

**Graphics APIs:**
- Desmarcamos *Auto Graphics API*.
- Removemos Vulkan, mantendo apenas OpenGLES3.

**Minimum API Level:**
- Definiu-se como Android 7.0 'Nougat' (API Level 24) ou superior.

**Arquitetura (64-bit):**
- Alterou-se o *Scripting Backend* de Mono para IL2CPP.
- Em *Target Architectures*, marcou-se ARM64 (além de ARMv7).

### 6. Geração do APK
- No caminho: `File > Build`.
- Aguardou-se a compilação (aproximadamente 15 a 20 minutos devido ao IL2CPP).
- Transferiu-se o arquivo `.apk` para o celular.

### 7. Como abrir e rodar no Unity:
1. Clique em Code > Download ZIP.
2. Extraia a pasta.
3. No Unity Hub, clique em Add e selecione a pasta extraída.
4. Aguarde a importação (pode demorar alguns minutos enquanto o Unity recria os arquivos de sistema).

Nota sobre os arquivos:
Para tornar o download mais rápido e leve, este repositório contém apenas os arquivos essenciais (Assets, Packages, ProjectSettings).
Não se preocupe se sentir falta da pasta Library: O Unity irá gerar automaticamente todos os arquivos de biblioteca e temporários necessários na primeira vez que você abrir o projeto.
