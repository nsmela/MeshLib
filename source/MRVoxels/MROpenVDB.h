#pragma once

#include <MRPch/MRSuppressWarning.h>
#include <MRPch/MRTBB.h>

#ifndef M_PI
#define M_PI   3.1415926535897932384626433832795
#endif

#ifndef M_PI_2
#define M_PI_2 1.5707963267948966192313216916398
#endif

MR_SUPPRESS_WARNING_PUSH

#ifdef _MSC_VER
#pragma warning(disable:4005) // 'M_PI': macro redefinition
#pragma warning(disable:4127)
#pragma warning(disable:4146)
#pragma warning(disable:4180) // qualifier applied to function type has no meaning; ignored
#pragma warning(disable:4242) // '=': conversion from 'int' to 'char', possible loss of data
#pragma warning(disable:4244)
#pragma warning(disable:4251)
#pragma warning(disable:4275)
#pragma warning(disable:4355) //'this': used in base member initializer list
#pragma warning(disable:4459) //declaration of 'compare' hides global declaration
#pragma warning(disable:4464) //relative include path contains '..'
#pragma warning(disable:4701) //potentially uninitialized local variable 'inv' used
#pragma warning(disable:4702) //unreachable code
#pragma warning(disable:4800) // Implicit conversion from '_Ty' to bool.
#pragma warning(disable:4868) //compiler may not enforce left-to-right evaluation order in braced initializer list

#pragma warning(disable:6297)  //Arithmetic overflow:  32-bit value is shifted, then cast to 64-bit value.  Results might not be an expected value.
#pragma warning(disable:26451) //Arithmetic overflow: Using operator '-' on a 4 byte value and then casting the result to a 8 byte value. Cast the value to the wider type before calling operator '-' to avoid overflow (io.2).
#pragma warning(disable:26495) //Variable 'openvdb::v7_1::math::Tuple<4,int>::mm' is uninitialized. Always initialize a member variable (type.6).
#pragma warning(disable:26812) //The enum type 'openvdb::v7_1::GridClass' is unscoped. Prefer 'enum class' over 'enum' (Enum.3).
#pragma warning(disable:26815) //The pointer is dangling because it points at a temporary instance which was destroyed.

// unknown pragmas
#pragma warning(disable:4068)
#endif

#if defined(__GNUC__)
#pragma GCC diagnostic ignored "-Wdeprecated-declarations"
#if __GNUC__ == 12 || __GNUC__ == 13
#pragma GCC diagnostic ignored "-Wmissing-template-keyword"
#endif
#endif

#if __clang_major__ >= 19 || __apple_build_version__ >= 17000000
#pragma clang diagnostic ignored "-Wmissing-template-arg-list-after-template-kw"
#endif

#ifdef __EMSCRIPTEN__
#pragma clang diagnostic ignored "-Wabsolute-value"
#endif

#define IMATH_HALF_NO_LOOKUP_TABLE // fix for unresolved external symbol "imath_half_to_float_table"


// Forward-declare some classes with default visibility. Otherwise on Mac the `dynamic_cast` to `openvdb::FloatGrid` can return null even if the type is correct.
// All those types are the components of the `openvdb::FloatGrid` typedef (including the template arguments...).
#ifdef __APPLE__
#include <openvdb/version.h> // For `OPENVDB_VERSION_NAME`, `OPENVDB_USE_VERSION_NAMESPACE`.
#include <openvdb/Types.h> // For `Index`.
namespace openvdb
{
OPENVDB_USE_VERSION_NAMESPACE
namespace OPENVDB_VERSION_NAME
{
    template <typename _TreeType>
    class __attribute__((__visibility__("default"))) Grid;

    namespace tree
    {
        template <typename _RootNodeType>
        class __attribute__((__visibility__("default"))) Tree;
        template<typename ChildType>
        class __attribute__((__visibility__("default"))) RootNode;
        template<typename _ChildNodeType, Index Log2Dim>
        class __attribute__((__visibility__("default"))) InternalNode;
        template<typename T, Index Log2Dim>
        class __attribute__((__visibility__("default"))) LeafNode;
    } // namespace tree
} // namespace OPENVDB_VERSION_NAME
} // namespace openvdb
#endif


#include <openvdb/openvdb.h>
#include <openvdb/io/Stream.h>
#include <openvdb/tools/Composite.h>
#include <openvdb/tools/GridTransformer.h>
#include <openvdb/tools/MeshToVolume.h>
#include <openvdb/tools/VolumeToMesh.h>
#include <openvdb/tools/Dense.h>
#include <openvdb/tools/Filter.h>

MR_SUPPRESS_WARNING_POP

#ifdef _WIN32
//clean up after windows.h
#undef small
#undef APIENTRY
#undef M_PI
#undef M_PI_2
#endif
