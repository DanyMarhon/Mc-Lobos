# 🍔 Mc Lobos - Sistema de Gestión de Pedidos de Comida Rápida

**Mc Lobos** es una aplicación web desarrollada para gestionar de forma eficiente los pedidos en un local de comida rápida. 
Ofrece una experiencia moderna tanto para usuarios como para administradores, permitiendo tomar pedidos, administrar el menú, 
procesar múltiples formas de pago y analizar estadísticas detalladas.

## 🚀 Funcionalidades Principales

- 🛒 **Toma de Pedidos Online:** Carga de pedidos por tipo (en local, para llevar o delivery).
- 🧍‍♂️ **Gestión de Clientes:** Registro de datos y seguimiento de historial.
- 💳 **Múltiples Formas de Pago:** Efectivo, tarjetas y billeteras virtuales.
- 📊 **Estadísticas Detalladas:** Reportes por producto, pago, tiempo, tipo de pedido, etc.
- 🚚 **Seguimiento de Pedidos:** Estados visibles (Recibido, En preparación, Listo, Entregado).
- 🍟 **Gestión de Menú:** Alta, baja y modificación de productos, combos y precios.

## 🛠️ Tecnologías Utilizadas

- **Frontend:** Blazor Server (UI interactiva en tiempo real)
- **Backend:** ASP.NET Core MVC
- **ORM:** Entity Framework Core + Patrón Unit of Work
- **Base de Datos:** SQL Server (Code First)
- **Arquitectura:** N-capas (Presentación, Aplicación, Dominio, Persistencia)

## 🧱 Arquitectura

- **Presentación:** Interfaz web Blazor
- **Aplicación:** Servicios de lógica y controladores
- **Dominio:** Entidades y reglas de negocio
- **Persistencia:** EF Core, Repositorios y Unit of Work

## 📦 Instalación

1. Cloná el repositorio:
   ```bash
   git clone https://github.com/DanyMarhon/TPInvOp2025.git



Respuesta sobre bajas lógicas:
✅ ¿Qué es una baja lógica?
Una baja lógica consiste en marcar un registro como "inactivo" o "eliminado" sin borrarlo realmente de la base de datos. Esto permite conservar la información histórica y evitar problemas de integridad referencial.

🧩 Cambios necesarios por componente
1. Base de datos
Se debe agregar un nuevo campo (por ejemplo, IsDeleted o Activo) de tipo booleano en cada una de las tablas afectadas. Este campo indicará si el registro está activo o ha sido eliminado lógicamente.

2. Modelos
Las entidades del dominio deben incorporar este nuevo campo para que pueda ser accedido y modificado desde la lógica de la aplicación.

3. DTOs y ViewModels
Deben reflejar el nuevo campo si es necesario mostrarlo en la interfaz o permitir la reactivación de registros desde la UI. En casos donde no sea relevante para la vista, puede omitirse.

4. Servicios
El método de eliminación debe cambiar: en lugar de borrar el registro, simplemente se actualiza el campo IsDeleted o Activo.

Los métodos de obtención de datos (GetAll, Find, etc.) deben filtrar los registros eliminados lógicamente para no incluirlos en los resultados.

Si se desea permitir la recuperación de registros eliminados, se debe implementar una función de "reactivación" que revierta la baja lógica.

5. Controladores
Los endpoints deben ajustarse para utilizar la lógica de baja lógica. También se pueden agregar nuevos endpoints para manejar la reactivación de registros.

6. Vistas (interfaz de usuario)
Se pueden ocultar registros eliminados o marcarlos visualmente como inactivos.

Opcionalmente, se puede permitir al usuario reactivar registros previamente eliminados.

Las acciones (como editar o eliminar) deben deshabilitarse para registros inactivos, si corresponde.

🎯 Beneficios de las bajas lógicas
Conserva la integridad referencial y evita errores por eliminación de registros relacionados.

Permite recuperación de registros eliminados.

Facilita auditorías e historial de datos.
