   M S B A M L   `   `   `  ����  Formula1    Formula1.InformesPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  ClasificacionPage��5      .��5	      � $��Center=�6   $	��550��6'   $��Center=�63    � 	Resources 5
   
    �� 
TargetType �� Property �� Value��%}   '��       �� 5      " ��6   .�5      ��  � ��$ Center=�66   �� 5       � ��$ Right=�68   5      5       � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6    � RowDefinitions 5   
   �� 5      $�� auto �6   �� 5      $�� auto �6   �� 5      $�� auto �6   .+�5   
   �� $��Edicion:��6   $��2��6#   $
��8,15q�64   �� 5   
   $��Gran premio:��6   $
��8,15q�6'   �� 5   
   $��Pilotos:��6   $��1��6#   �� 5   
   $��
Temporada:��6   $��2��6%   �� 5    
   $��1��6   $	��150��6J    �� DisplayMemberPath$ Valor��6V   $��Center=�6�   $
��8,15q�6�   ��6#   �� *GrandesPremios+ �� SelectedItem 6p   �� *GranPremioSeleccionado+	 �� UpdateSourceTrigger$	 PropertyChanged=�6�   �� 5!   
   $��1��6   $��3��6#   $��1��67   $ Valor��6d   $��Center=�6�   $
��8,15q�6�   ��6D   �� *	Pilotos+ 6~   �� *PilotoSeleccionado+$	 PropertyChanged=�6�   �� 5"   
   $��1��6   $��3��6#   $��2��67   $��Center=�6�   $
��8,15q�6�   ��6D   �� *
Temporadas+ 6g   �� *TemporadaSeleccionada+$	 PropertyChanged=�6�   �� 5#   
   $��3��6   $	��100��6#   $ Valor��6u   $��Center=�6�   ��6/   �� *	Ediciones+$	 PropertyChanged=� 6�   �� *EdicionSeleccionada+$	 PropertyChanged=�6�   �� 5$   
   $��Buscar��6   $��4��6"   $��Center=�6e   $
��8,15q�6�   $	��100��6�   ��62   �� * VerParticipantesEdicionCommand+6�   �� 5%   
   $��Buscar��6   $��4��6"   $��1��62   $��Center=�6d   $
��8,15q�6   $	��100��6�   ��6?   �� *VerPilotoCommand+6�   �� 5&   
   $��Buscar��6   $��4��6"   $��2��62   $��Center=�6h   $
��8,15q�6�   $	��100��6�   ��6?   �� *VerGranPremioCommand+6�   5'      5(      