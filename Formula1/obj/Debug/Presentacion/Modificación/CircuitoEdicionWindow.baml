   M S B A M L   `   `   `  ����C  ?Formula1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Formula1Formula1  5   	   $    Formula1.CircuitoEdicionWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5   	   +muxc using:Microsoft.UI.Xaml.Controls  5   	   "localclr-namespace:Formula1  5   	   $	��450��5
   "   $	��500��6/     � Title  6	   �� *Titulo+ � 	Resources 5       �� 
TargetType �� Property �� Value��%F  '��       '�� �     �� 5   
   " ��6   .�5      ��  � ��$ Right=�64   �� 5       � ��$
 8,15q�6'   �� 5       � ��$ Center=�69   5      �� 5   
   " ��6   .�5      ��  � ��$  auto��6'   �� 5       � ��$
 8,15q�6'   �� 5       � ��$ Center=�69   5      5      .��5      � $��Center=�6   $��Center=�6&    � RowDefinitions 5   
   �� 5      �� 5      $�� AUTO �6   .+�5   
   � $��Center=�6   $��Center=�6,    � ColumnDefinitions 5      �� 5      �� 5      $
�� 150 �6#    5!      �� 5"      �� 5#      $�� auto �6    �� 5$      �� 5%      �� 5&      �� 5'      .+�5)      �� $��Circuito��6   $��32(�6'   $�� 2��65   $�� 0q�6J   $��Center=�6V   �� 5*      $��Nombre:��6   $�� 1��6&   �� 5+      $��Ciudad:��6   $�� 2��6&   �� 5,      $��Pais:��6   $�� 3��6$   �� 5-      $��	Longitud:��6   $�� 4��6(   �� 5.      $��Curvas:��6   $�� 5��6&   �� 5/      $��1��6M   $��1��6]   ��6   �� *Nombre+ �� UpdateSourceTrigger$ 	LostFocus=�6]   �� 50      $��1��6M   $��2��6]   ��6   �� *Ciudad+$ 	LostFocus=�6]   �� 51       �� DisplayMemberPath$ Nombre��66   $
��8,15q�6�   $�� 1��6�   $�� 3��6�   $��Center=�6�   ��6   �� *Paises+	 �� SelectedItem	 6Q   �� *PaisSeleccionado+$ 	LostFocus=�6�   �� 52      $�� 1��6O   $�� 4��6`   ��6   �� *
Longitud+$ 	LostFocus=�6`   �� 53      $�� 1��6S   $�� 5��6d   ��6   �� *Curvas+$ PropertyChanged=�6d   55      �� 56   
   
 �� Orientation$
 
Horizontal=�6   $�� AUTO��6.   $�� 1��6=   y�6L   �� *
VerEdicion+.+�57      �� $��Guardar��6   $�� 150 ��6'   ��65   �� *GuardarCircuitoCommand+�� 58      $��Eliminar��6   $�� 15,0q�6(   $
�� 150��67   ��6D   �� *EliminarCircuitoCommand+59      �� 5:   
   $��Guardar��6   $�� 1��6#   $�� 2��61   $�� 150 ��6F   $��Center=�6   ��6T   �� *GuardarCircuitoCommand+y�6�   �� *VerCreacion+5;      5=      