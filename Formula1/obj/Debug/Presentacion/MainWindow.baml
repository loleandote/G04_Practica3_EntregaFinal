   M S B A M L   `   `   `  ����  Formula1    Formula1.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5   	     � Title$
  Menu��5	   	   $	��500��6   $	��800��6#    � 	Resources 5
       �� 
TargetType �� Property �� Value��%u  '��       '�� �     '_�     '�� K    �� 5   
   " ��6   .�5      ��  � ��
 ��iA�6+   �� 5       � ��
 �����6,   �� 5       � ��$  1q�60   5      �� 5   
   " ��6   .�5      ��  � ��$  5q�6'   �� 5       � ��$	  40��6&   5      �� 5   
   " _�6   .�5      ��  � ��
 �����6+   5      �� 5   
   " ��6   .�5      ��  � ��$
  4,8q�6'   �� 5       � ��$ 0q�6(   �� 5       � ��$ 60��6&   �� 5       � ��
 ���� 6+   �� 5       � ��$ 0q�60   �� 5       � ��$ Center=�64   5      5      .��5       ]� .+�5!   
   � $
��Left=�6   
����iA�$	�� 60��6<    � RowDefinitions 5"      �� 5#      $�� auto �6    �� 5$      $�� auto �6    �� 5%      $�� auto �6    �� 5&      $�� auto �6    �� 5'      $�� auto �6    .+�5)      ��  � ToolTip$ Pilotos��6]   ��6   �� *PilotosCommand+ �� UpdateSourceTrigger$ PropertyChanged=���5*      �� 5+      ._�5,      �� $%��/Presentacion/Iconos/Piloto.png��6$   5-      5/      �� 50      $��1��6   $ Paises��6i   ��6"   �� *PaisesCommand+$ PropertyChanged=���51      �� 52      ._�53      �� $#��/Presentacion/Iconos/Pais.png��6    54      56      �� 57      $�� 2��6   $ Gran Premio��6k   ��6#   �� *PremiosCommand+$ PropertyChanged=���58      �� 59      ._�5:      �� $)��#/Presentacion/Iconos/GranPremio.png��6    5;      5=      �� 5>      $��3��6   $ 	Circuitos��6"   ��66   �� *CircuitosCommand+$ PropertyChanged=���5@      �� 5A      $�� 1q�6   ._�5B      �� $'��!/Presentacion/Iconos/Circuito.png��6    5C      5E      �� 5F      $��4��6   $ Informes��6j   ��6"   �� *InformeCommand+$ PropertyChanged=���5G      �� 5H      ._�5I      �� $&�� /Presentacion/Iconos/Informe.png��6    5J      5L      5M       � 5N   
     � NavigationUIVisibility$ Hidden=�6R   ��6   �� *
Pantalla+$ PropertyChanged=�6R   5O      5P      