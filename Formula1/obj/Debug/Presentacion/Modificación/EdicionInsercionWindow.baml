   M S B A M L   `   `   `  ����C  ?Formula1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Formula1Formula1  5   	   %    Formula1.EdicionInsercionWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5   	   "localclr-namespace:Formula1  5   	   $	��300��5	   "   $	��500��6/     � Title  6	   �� *Titulo+ � 	Resources 5
       �� 
TargetType �� Property �� Value��%F  '��       '�� �     �� 5   
   " ��6   .�5      ��  � ��$ Right=�64   �� 5       � ��$
 8,15q�6'   �� 5       � ��$ Center=�69   5      �� 5   
   " ��6   .�5      ��  � ��$  auto��6'   �� 5       � ��$
 8,15q�6'   �� 5       � ��$ Center=�69   5      5      .��5      � $��Center=�6   $��Center=�6&    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $	��100��6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5       .+�5"   
   �� $��Fecha:��6   �� 5#   
   $��Nombre:��6   $��1��6"   �� 5$   
   $��	Circuito:��6   $��2��6$   (  "System.Windows.Controls.DatePicker  5%   
   $�� 1��6   $��Center=�6&   $
��8,15q�6~      SelectedDate 6A   �� *Fecha+ �� UpdateSourceTrigger$ 	LostFocus=�6~   �� 5&   
   $�� 1��6I   $�� 1��6W   ��6   �� *Nombre+$ 	LostFocus=�6W   �� 5'   
   $��2��6   $��1��6    	 �� DisplayMemberPath$	 Valor��6R   $��Center=�6l   $
��8,15q�6�   ��60   �� *	Circuitos+
 �� SelectedItem
 6�   �� *CircuitoSeleccionado+$ 	LostFocus=��� 5(   
   $��4��6   $��2��6   $��Guardar��62   ��6D   �� *CrearEdicionCommand+5)      5*      