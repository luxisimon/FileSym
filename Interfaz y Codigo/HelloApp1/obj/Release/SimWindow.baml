   M S B A M L   `   `   `  ���� D  @HelloApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:HelloApp1	HelloApp1      HelloApp1.Window1   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:HelloApp1     Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/    � Title$  Simulando...��$	��600��$
��1024�� � WindowStartupLocation$ CenterScreen=� � Topmost .  � 
ResizeMode$ CanMinimize=�.���  � Orientation$ Vertical=�.+�� .+�"  FontAwesome.WPF.ImageAwesome     Icon$ Spinner=�   Spin . $��25,5,0,0q�   SpinDuration$ 3Q�$��19��   
Foreground �#ff422c�� $%��Ejecutando instrucción 3 de 16��   	lblDesign#��[  $��13(�$'��!/HelloApp1;component/Font/#Ubuntu)����	#FFFF422C$��1,10,0,0q�$	��200��$
��Bold"��� $��Paso a paso��$	��100��$'��!/HelloApp1;component/Font/#Ubuntu)�$��	65,10,0,0q�$��30���� $
��Todo��$	��100��$'��!/HelloApp1;component/Font/#Ubuntu)�$��	15,10,0,0q�$��30���� $��Detener��$	��100��$'��!/HelloApp1;component/Font/#Ubuntu)�$��	15,10,7,0q�$��30���� $��Tiempo (seg)��#��[  $��12(�$'��!/HelloApp1;component/Font/#Ubuntu)����	#FFFF422C$��0,10,0,0q�$��83��$
��Bold"��� $��25��	 �� TextWrapping$
	 Wrap=�$��10��$��26��$��	0,10,10,0q�$'��!/HelloApp1;component/Font/#Ubuntu)��� -   $��Siguiente paso��$	��125��$'��!/HelloApp1;component/Font/#Ubuntu)�$��
85,10,15,0q�$��30��$
��Bold"��� ���	#FF1181A1$��1q�$��5,10,0,0q�$��1��$
��1000��� $ 
Horizontal=�$
��1024��.+��� -   $��lvDataBinding��$��25,5,0,0q�$	��460��$	��350��$'��!/HelloApp1;component/Font/#Ubuntu)�$��15(�
 �� View
 �� .P��� $��	Operacion�� �� Width$	 100�� �� DisplayMemberBinding �� *Nombre+�� $��Archivo��$	 120�� �� *	archivo+�� $��NP��$ 70�� �� *	n_proceso+�� $��Arribo��$ 70�� �� *arribo+�� $��Offset��$ 90�� �� *offset+�� -   $��lvDataBinding2��$��5,5,0,0q�$	��495��$	��350��$'��!/HelloApp1;component/Font/#Ubuntu)�$��14(��� ���	#FF1181A1$��1q�$��5,10,0,0q�$��1��$
��1000��� $ Vertical=�.+��� $
��Left=�$��Información adicional��#��[  $��22(�$'��!/HelloApp1;component/Font/#Ubuntu)����	#FFFF422C$��	35,10,0,0q�$	��250��$
��Bold"��� -    ��Name$ info_adicional��$
��Wrap=�$��13(�$'��!/HelloApp1;component/Font/#Ubuntu)����	#FFFF422C$��	15,10,0,0q�$
��1000��$
��Bold"�