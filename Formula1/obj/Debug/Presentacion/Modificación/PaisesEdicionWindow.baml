   M S B A M L   `   `   `  ����C  ?Formula1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:Formula1Formula1  5   	   "    Formula1.PaisesEdicionWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5   	   "localclr-namespace:Formula1  5   	   $	��300��5	   "   $	��400��6/     � Title  6	   �� *Titulo+.��5
      � $��Center=�6   $��Center=�6(    � RowDefinitions 5   
   �� 5      $�� auto �6   �� 5      $�� auto �6   �� 5      $�� auto �6   �� 5      $�� auto �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��País��6   $��32(�6   $�� 2��6-   $��Center=�6B   �� 5   
   $��Identificador:��6   $�� 1��6)   $��Right=�67   $�� 8,15q�6S   �� 5   
   $��Nombre:��6   $�� 2��6"   $��Right=�60   $�� 8,15q�6L   �� 5   
   $�� 1��6U   $�� 1��6c   $�� auto��6t   $�� 8,15q�6�    �� 
IsReadOnly . $
�� 100��6�   $��Center=�6�   ��6   �� *Identificador+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   $�� 2��6O   $�� 1��6]   $�� auto��6n   $�� 8,15q�6}   $
�� 100��6�   $��Center=�6�   ��6   �� *Nombre+$ PropertyChanged=�6�   �� 5   
    �� Orientation$ 
Horizontal=�6   $�� AUTO��6.   $�� 3��6=   $�� 2��6K   y�6`   �� *
VerEdicion+.+�5      �� $��Guardar��6   $�� 150 ��6'   $��Center=�6\   ��65   �� *GuardarPaisCommand+6\   �� 5      $��Eliminar��6   $�� 15,0q�6(   $
�� 150��67   ��6D   �� *EliminarPaisCommand+5      �� 5   
   $��Guardar��6   $�� 3��6#   $�� 2��61   $�� 150 ��6F   $��Center=�6{   ��6T   �� *GuardarPaisCommand+y�6�   �� *VerCreacion+5       5!      